using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Collision : MonoBehaviour
{
    public int hit_life; //need for wave setter
    [SerializeField] ParticleSystem Hit_particle;
    [SerializeField] ParticleSystem Deadth_particle;
    [SerializeField] AudioSource main_sorce;
    [SerializeField] AudioClip shot_sfx;
    [SerializeField] AudioClip death_sfx;

    private void Start()
    {
       hit_life=FindObjectOfType<Wave_Setter>().wave_health();
    }
    private void OnParticleCollision(GameObject other)
    {
        check_if_dead((other.GetComponentInParent<Tower_Behavior>().gameObject.name));
    }
    void check_if_dead(string Tower_name)
    {
        if (hit_life <= 0)
        {
            Kill_Enemy();
        }
        else
        {
            hit(Tower_name);
        }
    }

    private void Kill_Enemy()
    {
        FindObjectOfType<Score>().score_change(10);
        var death_partice_obj = Instantiate(Deadth_particle, transform.position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(death_sfx,Camera.main.transform.position);
        Destroy(death_partice_obj.gameObject, Deadth_particle.main.duration);
        Destroy(gameObject);
    }

    private void hit(string Tower_name)
    {
        print(Tower_name);
        if (Tower_name == "Slow_Tower(Clone)")
        {
            hit_life = hit_life - 3;
            FindObjectOfType<Score>().score_change(3);
        }
        else
        {
            hit_life--;
            FindObjectOfType<Score>().score_change(1);
        }
        main_sorce.PlayOneShot(shot_sfx);
        Hit_particle.Play();
    }
}
