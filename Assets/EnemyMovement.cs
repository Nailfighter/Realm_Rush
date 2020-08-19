using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    [SerializeField] List<Waypoint> path;
    [SerializeField] float time_to_hop=1f;
	void Start () 
    {
        path = FindObjectOfType<Pathfinder>().return_path();
        StartCoroutine(FollowPath());
	}

    IEnumerator FollowPath()
    {
        print("Starting patrol..."); 
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(time_to_hop);
        }
        print("Ending patrol");
    }
}
