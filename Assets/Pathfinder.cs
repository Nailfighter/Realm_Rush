using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Pathfinder : MonoBehaviour {

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    [SerializeField] Waypoint start_block, end_block;
    Vector2Int[] directions = {Vector2Int.up, Vector2Int.right,Vector2Int.down,Vector2Int.left};
	void Start ()
    {
        LoadBlocks();
        color_change();
        exploring_neighbor();
    }

    private void exploring_neighbor()
    {
        foreach(Vector2Int direction in directions)
        {
            Vector2Int explore_pos = direction + start_block.GetGridPos();
            if (grid.ContainsKey(explore_pos))
            {
                grid[explore_pos].set_color(Color.cyan);
            }
        }
    }

    public void color_change()
    {
        start_block.set_color(Color.red);
        end_block.set_color(Color.green);
    }

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();
        foreach (Waypoint waypoint in waypoints )
        {
            var waypoint_pos = waypoint.GetGridPos();
            if (grid.ContainsKey(waypoint_pos))
            {
                Debug.LogWarning("Duplicate cube spawned in same position-" + waypoint_pos);
            }
            else
            {
                grid.Add(waypoint_pos, waypoint);
            }
        }
    }
}
