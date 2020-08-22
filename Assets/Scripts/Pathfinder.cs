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
    public List<Waypoint> path = new List<Waypoint>();
	public List<Waypoint> return_path ()
    {
        if (path.Count()==0)
        {
            LoadBlocks();
            BFS_Algo();
            path_creator();
        }
        return path;

    }

    private void path_creator()
    {
        Add_path(end_block);
        end_block.is_placeble = false;
        Waypoint previous = end_block.explored_from;
        while (previous != start_block)
        {
            Add_path(previous);
            previous = previous.explored_from;
        }
        Add_path(start_block);
        path.Reverse();
    }

    private void Add_path(Waypoint previous)
    {
        path.Add(previous);
        previous.is_placeble = false;
    }

    private void BFS_Algo()
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
        if (grid.ContainsKey(explore_pos) && !grid[explore_pos].is_explored && queue.Contains(grid[explore_pos]) == false && grid[explore_pos].can_be_path)
        {
            queue.Enqueue(grid[explore_pos]);
            grid[explore_pos].explored_from=search_center;
        }
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
