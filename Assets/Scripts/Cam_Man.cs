using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam_Man : MonoBehaviour
{
    [SerializeField] GameObject Cam_1;
    [SerializeField] GameObject Cam_2;
    [SerializeField] GameObject Health;
    [SerializeField] GameObject Player_UI;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Cam_1.SetActive(false);
            Cam_2.SetActive(true);
            Player_UI.SetActive(true);

        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            Cam_1.SetActive(true);
            Cam_2.SetActive(false);
            Player_UI.SetActive(false);
        }
    }
    public void LateUpdate()
    {
        if(Camera.main.name== "Up_Cam")
        {
            Health.transform.rotation = Quaternion.Euler(-50, 180, 0);
            return;
        }

        Health.transform.LookAt(Cam_1.transform);
    }
}
