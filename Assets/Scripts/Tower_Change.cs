﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Change : MonoBehaviour
{
    [SerializeField] Tower_Behavior SLow_Tow;
    [SerializeField] Tower_Behavior Fast_Tow;
    [SerializeField] Tower_Factory tower_Factory;

    public void Start()
    {
        tower_Factory.tower = SLow_Tow;
        tower_Factory.is_2_tower = false;
    }
    public void change_1_to_2()
    {
        tower_Factory.tower = Fast_Tow;
        tower_Factory.is_2_tower = true;
    }
    public void change_2_to_1()
    {
        tower_Factory.tower = SLow_Tow;
        tower_Factory.is_2_tower = false;
    }


}