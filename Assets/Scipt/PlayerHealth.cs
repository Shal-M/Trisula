using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    static protected int currentHealth = 100;
    static protected int maxHealth = 100;
    public HealthBarPlayer healthBarPlayer;
    static protected int damage = 15;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(damage);
        Debug.Log(maxHealth);
        healthBarPlayer.SetMaxHealth(maxHealth, currentHealth);
        PlayerPrefs.SetInt("attack", damage);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(maxHealth);
    }

    public void EnemyAttack(int damage)
    {
        currentHealth -= damage;
        healthBarPlayer.SetHealth(currentHealth);
        if(currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
    public void increaseMaxHealth(int incMaxHealth)
    {
        maxHealth += incMaxHealth;
        healthBarPlayer.SetMaxHealth(maxHealth, currentHealth);
    }
    public void increaseAttack(int incMaxHealth)
    {
        damage += incMaxHealth;
        Debug.Log(damage);
        PlayerPrefs.SetInt("attack", damage);
    }
    public void restoreHealth()
    {
        currentHealth = maxHealth;
        healthBarPlayer.SetHealth(currentHealth);
        Debug.Log(currentHealth);
    }
}
