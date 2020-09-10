using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "High_Score_data", menuName = "Cus_data")]
public class High_Score_Data : ScriptableObject
{
    public int[] score=new int[8];
}
