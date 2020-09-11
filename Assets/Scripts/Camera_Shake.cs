using UnityEngine;
using System.Collections;

public class Camera_Shake : MonoBehaviour
{
    public float duration, magnitude;
    public High_Score_Data data;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            
        }
    }
    public IEnumerator Shake()
    {
        Vector3 orignalPosition = transform.position;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float x = Random.Range(orignalPosition.x-magnitude, orignalPosition.x+magnitude);
            float y = Random.Range(orignalPosition.y- magnitude, orignalPosition.y+ magnitude);

            transform.position = new Vector3(x, y,orignalPosition.z);
            elapsed += Time.deltaTime;
            yield return 0;
        }
        transform.position = orignalPosition;
    }

    public void score_modifier(int level, int score)
    {
        if (score > data.score[level])
        {
            data.score[level] = score;
        }
    }
}