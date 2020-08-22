using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Tower_Factory : MonoBehaviour
{
    [SerializeField] Tower_Behavior tower;
    [SerializeField] int Max_Tower=5;
    Queue<Tower_Behavior> Tower_Q = new Queue<Tower_Behavior>();
    [SerializeField] Transform Tower_parent;
    public void Add_Tower(Waypoint waypoint)
    {
        if (Tower_Q.Count()<Max_Tower)
        {
            Instantiate_Tower(waypoint);
            print(Tower_Q.Count);
        }
        else
        {
            Replace_Tower(waypoint);
        }

    }

    private void Instantiate_Tower(Waypoint waypoint)
    {
        var new_tower=Instantiate(tower, waypoint.transform.position, Quaternion.identity);
        new_tower.transform.parent = Tower_parent;
        new_tower.base_waypoint = waypoint;
        new_tower.base_waypoint.is_placeble = false;

        Tower_Q.Enqueue(new_tower);
    }


    private void Replace_Tower(Waypoint new_waypoint)
    {
        var old_tower = Tower_Q.Dequeue();

        old_tower.base_waypoint.is_placeble = true;
        new_waypoint.is_placeble = false;

        old_tower.base_waypoint = new_waypoint;


        old_tower.transform.position = new_waypoint.transform.position;

        Tower_Q.Enqueue(old_tower);
    }


}

