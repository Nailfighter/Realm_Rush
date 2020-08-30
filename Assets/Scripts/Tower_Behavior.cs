using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Tower_Behavior : MonoBehaviour
{
    public Transform Target_enemy;
    [SerializeField] ParticleSystem[] bullet;
    [SerializeField] float attack_range;
    public Waypoint base_waypoint;
    [SerializeField] GameObject rot;
    public int hit_ratio = 1;
    void Update()
    {
        check_for_closest();
        shooting_enemy();
    }

    private void check_for_closest()
    {
        var enemy_in_scene = FindObjectsOfType<EnemyMovement>();
        if (enemy_in_scene.Count() == 0) { return; }
        Transform clossest_enemy = enemy_in_scene[0].transform;
        foreach (EnemyMovement potential_enemy in enemy_in_scene)
        {
            clossest_enemy = Get_closet_enemy(clossest_enemy, potential_enemy.transform);
        }
        Target_enemy = clossest_enemy;
    }

    private Transform Get_closet_enemy(Transform clossest_enemy, Transform potential_enemy)
    {
        float clos_dis = Vector3.Distance(transform.position, clossest_enemy.position);
        float pot_dis = Vector3.Distance(transform.position, potential_enemy.position);
        if (clos_dis > pot_dis) { return potential_enemy; }
        else { return clossest_enemy; }
    }

    private void shooting_enemy()
    {
        foreach (ParticleSystem bullet in bullet)
        {
            var emission = bullet.emission;
            if (!Target_enemy)
            {
                emission.enabled = false;
                return;
            }
            float enemy_dis = Vector3.Distance(Target_enemy.position, transform.position);
            if (enemy_dis <= attack_range)
            {
                rot.transform.LookAt(Target_enemy);
                emission.enabled = true;
            }
            else
            {
                emission.enabled = false;
            }
        }

    }
}














//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using UnityEngine;

//public class Tower_Behavior : MonoBehaviour
//{
//    public Transform Target_enemy;
//    [SerializeField] ParticleSystem bullet;
//    [SerializeField] float attack_range;
//    public Waypoint base_waypoint;
//    void Update()
//    {
//        check_for_closest();
//        shooting_enemy();
//    }

//    private void check_for_closest()
//    {
//        var enemy_in_scene = FindObjectsOfType<EnemyMovement>();
//        if (enemy_in_scene.Count() == 0) { return; }
//        Transform clossest_enemy = enemy_in_scene[0].transform;
//        foreach(EnemyMovement potential_enemy in enemy_in_scene)
//        {
//            clossest_enemy = Get_closet_enemy(clossest_enemy, potential_enemy.transform);
//        }
//        Target_enemy = clossest_enemy;
//    }

//    private Transform Get_closet_enemy(Transform clossest_enemy, Transform potential_enemy)
//    {
//        float clos_dis = Vector3.Distance(transform.position, clossest_enemy.position);
//        float pot_dis = Vector3.Distance(transform.position, potential_enemy.position);
//        if (clos_dis > pot_dis) { return potential_enemy; }
//        else { return clossest_enemy; }
//    }

//    private void shooting_enemy()
//    {
//        var emission = bullet.emission;
//        if (!Target_enemy)
//        {
//            emission.enabled = false;
//            return;
//        }
//        float enemy_dis = Vector3.Distance(Target_enemy.position, transform.position);
//        if (enemy_dis <= attack_range)
//        {
//            transform.Find("Tower_A_Top").LookAt(Target_enemy);
//            emission.enabled=true;
//        }
//        else
//        {
//            emission.enabled = false;
//        }
//    }
//}
