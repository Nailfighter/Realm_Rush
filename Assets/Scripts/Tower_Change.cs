using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower_Change : MonoBehaviour
{
    [SerializeField] Tower_Behavior Slow_Tow;
    [SerializeField] Tower_Behavior Fast_Tow;
    [SerializeField] Tower_Factory tower_Factory;
    [SerializeField] GameObject Slow_tower_Img;
    [SerializeField] GameObject Fast_Tower_Img;

    public void Start()
    {
        tower_Factory.tower = Fast_Tow;
        tower_Factory.is_2_tower = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            change_2_to_1();
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            change_1_to_2();
        }
    }
    public void change_1_to_2()
    {
        tower_Factory.tower = Slow_Tow;
        tower_Factory.is_2_tower = true;
        Slow_tower_Img.SetActive(true);
        Fast_Tower_Img.SetActive(false);
    }
    public void change_2_to_1()
    {
        tower_Factory.tower = Fast_Tow;
        tower_Factory.is_2_tower = false;
        Slow_tower_Img.SetActive(false);
        Fast_Tower_Img.SetActive(true);
    }

    //

}
