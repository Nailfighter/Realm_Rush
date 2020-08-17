using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Pathfinder : MonoBehaviour {

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();
    [SerializeField] Waypoint start_block, end_block;
    Vector2Int[] directions = {Vector2Int.up, Vector2Int.right,Vector2Int.down,Vector2Int.left};
    bool is_algorithim_running = true;
    Waypoint search_center;
	void Start ()
    {
        LoadBlocks();
        color_change();
        Pathfind();
    }

    private void Pathfind()
    {
        queue.Enqueue(start_block);
        while (queue.Count > 0 && is_algorithim_running)
        {
            search_center=queue.Dequeue();
            stop_if_found();
            exploring_neighbor();
            search_center.is_explored = true;
        }
    }

    private void stop_if_found()
    {
        if (search_center == end_block)
        {
            print("Found the end block at"+end_block);
            is_algorithim_running = false;
        }
    }

    private void exploring_neighbor()
    {
        if (!is_algorithim_running) { return; }
        foreach (Vector2Int direction in directions)
        {
            get_neighbour_pos(direction);
        }
        
    }

    private void get_neighbour_pos(Vector2Int direction)
    {
        Vector2Int explore_pos = direction + search_center.GetGridPos();
        if (grid.ContainsKey(explore_pos) && !grid[explore_pos].is_explored && queue.Contains(grid[explore_pos]) == false)
        {
            queue.Enqueue(grid[explore_pos]);
            grid[explore_pos].explored_from=search_center;
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
