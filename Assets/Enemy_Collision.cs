using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Collision : MonoBehaviour
{
    [SerializeField] int hit_life;
    private void OnParticleCollision(GameObject other)
    {
        check_if_dead();
    }
    void check_if_dead()
    {
        if (hit_life <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            hit();
        }
    }

    private void hit()
    {
        hit_life--;
    }
}
