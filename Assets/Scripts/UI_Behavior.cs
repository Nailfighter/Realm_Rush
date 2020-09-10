using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Behavior : MonoBehaviour
{
    public GameObject reset_text;
    public High_Score_Data data;
    public GameObject sample_block;
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
        if (SceneManager.GetActiveScene().buildIndex == 0 || SceneManager.GetActiveScene().buildIndex == 8)
        {
            foreach (Text text in FindObjectsOfType<Text>())
            {
                text.color = sample_block.GetComponent<Renderer>().material.GetColor(("_EmissionColor"));
            }
        }


    }
    public void restart_level()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    public void next_level()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void level_selector(GameObject caller)
    {
        SceneManager.LoadScene(int.Parse(caller.name));
    }

    public void reset_score()
    {
        for (int i = 0; i < data.score.Length; i++)
        {
            data.score[i] = 0;
        }
        StartCoroutine(message());
    }
    IEnumerator message()
    {
        reset_text.SetActive(true);
        yield return new WaitForSeconds(3f);
        reset_text.SetActive(false);
    }
}
