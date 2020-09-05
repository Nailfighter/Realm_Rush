using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class text_world_color : MonoBehaviour
{
    [SerializeField] Text[] own_text;
    [SerializeField] GameObject sample_world_cube;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Text own_text in own_text)
        {
            own_text.color = sample_world_cube.GetComponent<Snap_Environment>().color;
        }

    }
}
