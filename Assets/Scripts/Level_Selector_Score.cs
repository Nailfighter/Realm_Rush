using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level_Selector_Score : MonoBehaviour
{
    [SerializeField] Text[] Score_Text;
    public High_Score_Data data;

    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            int count = 0;
            foreach (Text scoretext in Score_Text)
            {
                count++;
                scoretext.text = "Score-" + data.score[count];

            }
        }
    }


  
}
