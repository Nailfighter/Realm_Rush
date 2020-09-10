using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class Enemy_Spawner : MonoBehaviour
{
    public float spawn_time=2f; //wave setter
    [SerializeField] EnemyMovement enemy;
    bool Wave_over=false;
    private void Awake()
    {
        StartCoroutine(spawn_enemy());
    }

    public void Update()
    {
        StartCoroutine(end_game());
    }
    IEnumerator spawn_enemy()
    {
        int count_wave = 0;
        while (count_wave<FindObjectOfType<Wave_Setter>().num_of_wave)
        {
            int count = 0;
            while (count < FindObjectOfType<Wave_Setter>().spwan_at_wave)
            {
                var ennemy = Instantiate(enemy.gameObject, transform.position, Quaternion.identity);
                ennemy.transform.parent = transform;
                yield return new WaitForSeconds(spawn_time);
                count++;
            }
            yield return new WaitForSeconds(FindObjectOfType<Wave_Setter>().wave_delay);
            count_wave++;
        }
        Wave_over = true;
    }
    IEnumerator end_game()
    {
        if (FindObjectsOfType<Enemy_Collision>().Count()==0 && Wave_over)
        {
            FindObjectOfType<Score>().score_modifier(SceneManager.GetActiveScene().buildIndex, FindObjectOfType<Score>().cur_score);
            GameObject level_win = FindObjectOfType<Wave_Setter>().level_win_screen;
            level_win.SetActive(true);
            FindObjectOfType<Player_Base>().player_ui.SetActive(false);
            yield return new WaitForSeconds(2f);
            level_win.GetComponent<Animator>().enabled = false;
            Time.timeScale = 0f;
        }

    }


}
