using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Mouse_Control : MonoBehaviour
{
    public bool is_control=true;
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0)&& is_control)
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
            if (FindObjectsOfType<TypeWriterEffect>().Count() != 0)
            {
                FindObjectOfType<TypeWriterEffect>().type_message_box("You can't place the block there");
            }

        }
    }
}
