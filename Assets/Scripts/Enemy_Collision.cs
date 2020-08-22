using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Collision : MonoBehaviour
{
    [SerializeField] int hit_life;
    [SerializeField] ParticleSystem Hit_particle;
    [SerializeField] ParticleSystem Deadth_particle;
    private void OnParticleCollision(GameObject other)
    {
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
        var death_partice_obj = Instantiate(Deadth_particle, transform.position, Quaternion.identity);
        Destroy(death_partice_obj.gameObject, Deadth_particle.main.duration);
        Destroy(gameObject);
    }

    private void hit()
    {
        hit_life--;
        Hit_particle.Play();
    }
}
