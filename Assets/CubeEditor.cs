using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour {

    Waypoint waypoint;
    private void Awake()
    {
        waypoint = GetComponent<Waypoint>();

    }

    void Update()
    {
        SnapToGrid();
        UpdateLabel();
    }

    private void SnapToGrid()
    {
        int gridSize = waypoint.GetGridSize();
        transform.position = new Vector3 (waypoint.GetGridPos().x*gridSize,0f,waypoint.GetGridPos().y*gridSize);
    }

    private void UpdateLabel()
    {
        TextMeshPro Label = GetComponentInChildren<TextMeshPro>();
        int gridSize = waypoint.GetGridSize();
        string labelText =waypoint.GetGridPos().x+","+waypoint.GetGridPos().y;
        Label.text = labelText;
        gameObject.name = "(" + labelText + ")";
    }
}
