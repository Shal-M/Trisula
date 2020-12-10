using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BosHealth : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    public HealthBarBos healthBarBos;
    

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBarBos.setHealth(currentHealth, maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayerAttack(int damage)
    {
        currentHealth -= damage;
        healthBarBos.setHealth(currentHealth, maxHealth);
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
