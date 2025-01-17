﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    Vector2Int gridPos;
    const int gridSize = 10;
    public bool is_explored = false;
    public Waypoint explored_from;
    public bool is_placeble=true;
    public bool can_be_path;

    public int GetGridSize()
    {
        return gridSize;
    }
	
    public Vector2Int GetGridPos()
    {
        return new Vector2Int( Mathf.RoundToInt(transform.position.x / gridSize),
                               Mathf.RoundToInt(transform.position.z / gridSize));
    }
}
