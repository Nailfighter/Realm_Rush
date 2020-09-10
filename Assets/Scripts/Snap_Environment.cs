using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Snap_Environment : MonoBehaviour
{
    public Color color;
    [SerializeField] bool is_random_y = true;
    [SerializeField] float color_time;
    float random_y;
    [SerializeField] float wait=1f;
    [SerializeField] Material RGB_Block;
    void Start()
    {
        random_y = Random.Range(-10, -20);
        StartCoroutine(up_down());
        StartCoroutine(color_change());
    }

    // Update is called once per frame
    void Update()
    {
        Vector2Int vector= new Vector2Int(Mathf.RoundToInt(transform.position.x / 10),(Mathf.RoundToInt(transform.position.z / 10)));
        if (is_random_y)
        {
            transform.position = new Vector3(vector.x * 10, random_y, vector.y * 10);
        }
        color_change();
    }
    IEnumerator up_down()
    {
        while (true)
        {
            float to_randam_y = Random.Range(-10, -20);
            while (random_y != to_randam_y)
            {
                if (random_y > to_randam_y)
                {
                    random_y--;
                }
                else
                {
                    random_y++;
                }
                yield return new WaitForSeconds(wait);
            }
        }

    }
    IEnumerator color_change()
    {
        while (true)
        {
            color = random_color_gen();
            RGB_Block.SetColor("_EmissionColor", color);
            yield return new WaitForSeconds(color_time);
        }

    }
    
    public Color random_color_gen()
    {
        float red;
        float green;
        float blue;
        red = Random.Range(56, 200);
        green = Random.Range(56, 200);
        blue = Random.Range(56, 200);
        Color r_color = new Color(red / 255, green / 255, blue / 255);
        return r_color;
    }

   
}
