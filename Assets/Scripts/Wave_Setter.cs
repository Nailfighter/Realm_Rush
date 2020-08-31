using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wave_Setter : MonoBehaviour
{
    //[de]spawn_time,[in]hit_life, [in]time_to_hop
    float time = 0f;
    public int count;


    [Space] [Header("Decrese in Wave")]
    [SerializeField] float red_time_to_hop=1f;
    [SerializeField] int inc_hit=1;
    [SerializeField] float dec_spawn=1f;

    [Space][Header("Related to wave")]
    public int num_of_wave=1;
    public float wave_delay=1f;
    [SerializeField] float duration_of_wave=1f;
    [SerializeField] Text wave_counter;

    [Space][Header("Inisitialisation")]
    [SerializeField] int Health=1;
    [SerializeField] float hop_time=1f;

    [Space]
    [Header("Inisitialisation")]
    [SerializeField] float min_spawn_time=3f;
    [SerializeField] float min_time_to_hop=3f;
    [SerializeField] int max_hit_life=5;
    public float time_clock()
    {
        time += Time.deltaTime;
        return Mathf.RoundToInt(time); ;
    }

    private void Start()
    {
        FindObjectOfType<Enemy_Spawner>().spawn_time += dec_spawn;
        Health -= inc_hit;
        hop_time += red_time_to_hop;
        StartCoroutine(wave());
    }
    IEnumerator wave()
    {
        while (count < num_of_wave)
        {
            count++;

            // Spawner()
            if (FindObjectOfType<Enemy_Spawner>().spawn_time>=min_spawn_time)
            {
                FindObjectOfType<Enemy_Spawner>().enabled = true;
                FindObjectOfType<Enemy_Spawner>().spawn_time -= dec_spawn;
            }

            // Wave Count Display
            wave_counter.text = "Wave " + count;
            StartCoroutine(FindObjectOfType<TypeWriterEffect>().Wave_Info());

            // Health()
            if (Health<=max_hit_life)
            {
                Health += inc_hit;
            }

            // Hoping()
            if (hop_time>=min_time_to_hop)
            {
                hop_time -= red_time_to_hop;
            }

            // Time to wait
            yield return new WaitForSeconds(duration_of_wave);
            FindObjectOfType<Enemy_Spawner>().enabled = false;
            yield return new WaitForSeconds(wave_delay);
        }
    }

    public int wave_health()
    {
        return Health;
    }
    public float time_to_hope()
    {
        return hop_time;
    }

}
