﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    [SerializeField] List<Waypoint> path;
    public float time_to_hop=1f; // wave setter
    [SerializeField] ParticleSystem goal_particle;
	void Start () 
    {
        time_to_hop = FindObjectOfType<Wave_Setter>().time_to_hope();
        path = FindObjectOfType<Pathfinder>().return_path();
        StartCoroutine(FollowPath());
	}

    IEnumerator FollowPath()
    {
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(time_to_hop);
        }
        Self_Destroy();
    }
    private void Self_Destroy()
    {
        var death_partice_obj = Instantiate(goal_particle, transform.position, Quaternion.identity);
        Destroy(death_partice_obj.gameObject, goal_particle.main.duration);
        Destroy(gameObject);
    }
}
