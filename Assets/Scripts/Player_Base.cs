using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_Base : MonoBehaviour
{
    [SerializeField] int Player_Life = 20;
    [SerializeField] AudioSource main_sorce;
    [SerializeField] AudioClip blsat_sfx;
    public GameObject player_ui;
    [SerializeField] GameObject death_ui;
    [SerializeField] float time_less;


    private void OnTriggerEnter(Collider other)
    {
        if (Player_Life <= 0)
        {
            player_ui.SetActive(false);
            death_ui.SetActive(true);
            Invoke("Time_Stop",3f);
            Invoke("animation_stop", 2f);
            Array Block = FindObjectsOfType<Mouse_Control>();
            foreach (Mouse_Control mouse in Block)
            {
                mouse.is_control = false;
            }
            FindObjectOfType<Score>().score_modifier(SceneManager.GetActiveScene().buildIndex, FindObjectOfType<Score>().cur_score);

        }
        else
        {
            Player_Life--;
            main_sorce.PlayOneShot(blsat_sfx);
            FindObjectOfType<Health_Bar_Slider>().health_slider(Player_Life);
            StartCoroutine(FindObjectOfType<Camera_Shake>().Shake());
        }
    }

    private void Time_Stop()
    {
        Time.timeScale = 0f;
    }
    private void Start()
    {
        FindObjectOfType<Health_Bar_Slider>().gameObject.GetComponent<Slider>().maxValue = Player_Life;
    }
    void animation_stop()
    {
        death_ui.GetComponent<Animator>().enabled = false;
    }
}
