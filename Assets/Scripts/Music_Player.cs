using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music_Player : MonoBehaviour
{
    private void Start()
    {
        int num_music_player = FindObjectsOfType<Music_Player>().Length;
        if (num_music_player > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);

        }
    }
}
