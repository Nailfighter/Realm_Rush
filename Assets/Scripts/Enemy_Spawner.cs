using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour
{
    [SerializeField] float spawn_time=2f;
    [SerializeField] EnemyMovement enemy;
    private void Start()
    {
        StartCoroutine(spawn_enemy());   
    }
    IEnumerator spawn_enemy()
    {
        while (true)
        {
            var ennemy=Instantiate(enemy.gameObject, transform.position, Quaternion.identity);
            ennemy.transform.parent = transform;
            yield return new WaitForSeconds(spawn_time);
        }
    }
}
