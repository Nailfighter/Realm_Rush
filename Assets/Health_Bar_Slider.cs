using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health_Bar_Slider : MonoBehaviour
{
    [SerializeField] Slider h_slider;
    [SerializeField] Gradient gradient;
    [SerializeField] Image fill;

    public void health_slider(int health)
    {
        h_slider.value = health;
        fill.color = gradient.Evaluate(h_slider.normalizedValue);
    }
}
