using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarPlayer : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    
    // Start is called before the first frame update
    public void SetMaxHealth(int health, int currentHealth)
    {
        slider.maxValue = health;
        slider.value = currentHealth;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void SetHealth(int health)
    {
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
