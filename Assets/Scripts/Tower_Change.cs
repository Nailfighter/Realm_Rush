using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower_Change : MonoBehaviour
{
    [SerializeField] Tower_Behavior Slow_Tow;
    [SerializeField] Tower_Behavior Fast_Tow;
    [SerializeField] Tower_Factory tower_Factory;
    [SerializeField] Button Slow_tower;
    [SerializeField] Button Fast_Tower;

    public void Start()
    {
        tower_Factory.tower = Fast_Tow;
        tower_Factory.is_2_tower = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            print("Frfrf");
        }
    }
    public void change_1_to_2()
    {
        tower_Factory.tower = Slow_Tow;
        tower_Factory.is_2_tower = true;
        Slow_tower.Select();

    }
    public void change_2_to_1()
    {
        tower_Factory.tower = Fast_Tow;
        tower_Factory.is_2_tower = false;
        Fast_Tower.Select();
    }


}
