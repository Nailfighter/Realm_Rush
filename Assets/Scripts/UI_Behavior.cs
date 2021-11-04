using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class UI_Behavior : MonoBehaviour
{
    public GameObject reset_text;
    public High_Score_Data data;
    public GameObject sample_block;
    public Toggle Graphic_Toggle;

    private GameObject Pos_Process;
    private void Awake()
    {
        Pos_Process = FindObjectOfType<PostProcessVolume>().gameObject;
    }
    private void Start()
    {
        if(Graphic_Toggle != null)
        {
            Graphic_Toggle.isOn = data.Fancy_Graphics;
        }

        Change_Quality();
    }
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

    private void Change_Quality()
    {
        foreach (var mov_cube in FindObjectsOfType<Snap_Environment>())
        {
            mov_cube.enabled = data.Fancy_Graphics;
        }
        Pos_Process.SetActive(data.Fancy_Graphics);
    }
    public void toggle_fancy_graphic(bool state)
    {
        data.Fancy_Graphics = state;
        Change_Quality();
    }


}
