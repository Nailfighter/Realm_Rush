using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Base : MonoBehaviour
{
    [SerializeField] int Player_Life=20;
    [SerializeField] int max_life;
    private void OnTriggerEnter(Collider other)
    {
        if (Player_Life <= 0)
        {
            print("Player DED");
        }
        else
        {
            Player_Life--;
            FindObjectOfType<Health_Bar_Slider>().health_slider(Player_Life);
        }
    }
}
