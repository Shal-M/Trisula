using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private static int damage;

    // Start is called before the first frame update
    void Start()
    {
        damage = PlayerPrefs.GetInt("attack");
        Debug.Log(damage);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Enemy")
            {
                EnemyHealth eHealth;
                eHealth = collision.gameObject.GetComponent<EnemyHealth>();
                eHealth.PlayerAttack(damage);
            }
            if (collision.tag == "Bos")
            {
                BosHealth bHealth;
                bHealth = collision.gameObject.GetComponent<BosHealth>();
                bHealth.PlayerAttack(damage);
            }
        }
}
