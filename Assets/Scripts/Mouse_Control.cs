using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse_Control : MonoBehaviour
{
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            chech_if_placeable();
        }
    }

    private void chech_if_placeable()
    {
       bool is_placeable=gameObject.GetComponent<Waypoint>().is_placeble;
        if (is_placeable)
        {
            FindObjectOfType<Tower_Factory>().Add_Tower(gameObject.GetComponent<Waypoint>());     
        }
        else
        {
            print("No,you can't place");
        }
    }
}
