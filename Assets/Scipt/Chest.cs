using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    public GameObject dialogBox;
    public Text dialogText;
    public string dialog;
    public bool inRange;
    public int counter = 0;
    [SerializeField]
    private int incMaxHealth;
    public bool open;
    private Animator anim;
    [SerializeField]
    private int incAtk;
    public bool increase;
    // Start is called before the first frame update
    void Start()
    {
        dialogBox.SetActive(false);
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K) && inRange)
        {
            if (!open)
            {

                dialogBox.SetActive(true);
                dialogText.text = dialog;
                anim.SetBool("isOpen", true);
                increase = true;
                open = true;
            }
            else
            {
                dialogBox.SetActive(false);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && open)
        {
            inRange = true;
        } 
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && increase)
        {
            inRange = true;
            collision.gameObject.GetComponent<PlayerHealth>().increaseAttack(incAtk);
            collision.gameObject.GetComponent<PlayerHealth>().increaseMaxHealth(incMaxHealth);
            increase = false;
        }
        else
        {
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inRange = false;
            dialogBox.SetActive(false);
        }
    }
}
