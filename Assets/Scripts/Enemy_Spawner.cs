using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour
{
    public float spawn_time=2f; //wave setter
    [SerializeField] EnemyMovement enemy;
    private void Awake()
    {
        Couroutin();
    }
    void Update()
    {
        
    }
    private void Couroutin()
    {
        StartCoroutine(spawn_enemy());
    }

    IEnumerator spawn_enemy()
    {
        while (this.enabled)
        {
            var ennemy=Instantiate(enemy.gameObject, transform.position, Quaternion.identity);
            ennemy.transform.parent = transform;
            yield return new WaitForSeconds(spawn_time);
        }
        Invoke("Couroutin", FindObjectOfType<Wave_Setter>().wave_delay);
    }
}
