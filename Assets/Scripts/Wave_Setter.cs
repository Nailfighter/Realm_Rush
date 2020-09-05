using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wave_Setter : MonoBehaviour
{
    //[de]spawn_time,[in]hit_life, [in]time_to_hop
    float time = 0f;
    public int count;
    public GameObject level_win_screen;
    [Header("Related to wave")]
    public int num_of_wave=1;
    public float wave_delay=1f;
    [SerializeField] float duration_of_wave=1f;
    public int spwan_at_wave;
    [SerializeField] Text wave_counter;

    [Header("Inisitialisation")]
    int Health=1;
    float hop_time=1f;

    [Header("Min,Max")]
    [SerializeField] int min_hit_life=2, max_hit_life = 5;
    [SerializeField] float min_time_to_hop = 3f, max_time_to_hop = 5f;
    public float time_clock()
    {
        time += Time.deltaTime;
        return Mathf.RoundToInt(time); ;
    }

    private void Start()
    {
        StartCoroutine(wave());
    }
    IEnumerator wave()
    {
        while (count < num_of_wave)
        {
            count++;

            Health = Random.Range(min_hit_life, max_hit_life);

            hop_time = Random.Range(min_time_to_hop, max_time_to_hop);

            wave_counter.text = "Wave " + count;
            StartCoroutine(FindObjectOfType<TypeWriterEffect>().Wave_Info());

            yield return new WaitForSeconds(duration_of_wave);
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
