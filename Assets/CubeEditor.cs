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
        transform.position = new Vector3 (waypoint.GetGridPos().x,0f,waypoint.GetGridPos().y);
    }

    private void UpdateLabel()
    {
        TextMeshPro Label = GetComponentInChildren<TextMeshPro>();
        int gridSize = waypoint.GetGridSize();
        string labelText =waypoint.GetGridPos().x / gridSize +","+waypoint.GetGridPos().y / gridSize;
        Label.text = labelText;
        gameObject.name = "Cube(" + labelText + ")";
    }
}
