using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Pathfinder : MonoBehaviour {

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
	void Start ()
    {
        LoadBlocks();
	}

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();
        foreach (Waypoint waypoint in waypoints )
        {
            var waypoint_pos = waypoint.GetGridPos() / waypoint.GetGridSize();
            if (grid.ContainsKey(waypoint_pos))
            {
                Debug.LogWarning("Duplicate cube spawned in same position-" + waypoint_pos);
                Destroy(waypoint.gameObject);
            }
            else
            {
                grid.Add(waypoint_pos, waypoint);
            }
        }
    }
}
