using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarBos : MonoBehaviour
{
    public Slider slider;
    public Color low;
    public Color high;
    // Start is called before the first frame update
    public void setHealth(int health, int maxHealth)
    {
        slider.gameObject.SetActive(health < maxHealth);
        slider.value = health;
        slider.maxValue = maxHealth;
    }
}
