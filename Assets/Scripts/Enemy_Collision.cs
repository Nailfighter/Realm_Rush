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
        print(other.GetComponentInParent<Tower_Behavior>().gameObject.name );
        check_if_dead();

    }
    void check_if_dead()
    {
        if (hit_life <= 0)
        {
            Kill_Enemy();
        }
        else
        {
            hit();
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

    private void hit()
    {
        hit_life--;
        FindObjectOfType<Score>().score_change(1);
        main_sorce.PlayOneShot(shot_sfx);
        Hit_particle.Play();
    }
}
