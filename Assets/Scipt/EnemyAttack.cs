using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyAttack : MonoBehaviour
{
    private PlayerHealth PHealth;
    public float waitToAttack = .2f;
    public bool isTouching;
    [SerializeField]
    private int damage;

    // Start is called before the first frame update
    void Start()
    {
        PHealth = FindObjectOfType<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isTouching)
        {
            waitToAttack -= Time.deltaTime;
            if (waitToAttack <= 0)
            {
                PHealth.EnemyAttack(damage);
                waitToAttack = 2f;
            }
        }   
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().EnemyAttack(damage);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            isTouching = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            isTouching = false;
            waitToAttack = 2f;
        }
    }
}
