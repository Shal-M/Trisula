using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDefense : MonoBehaviour
{
    public GameObject dialogBox;
    public Text dialogText;
    public string dialog;
    public bool inRange;
    public int counter = 0;
    [SerializeField]
    public int incMaxHealth;
    private PlayerHealth PHealth;
    public bool ambil;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        dialogBox.SetActive(false);
        ambil = false;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K) && inRange)
        {
            if (dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);
                counter++;
            }
            else
            {
                dialogBox.SetActive(true);
                dialogText.text = dialog;
                counter++;
            }
        }
        if (counter == 2)
        {
            ambil = true;
            counter = 0;
            anim.SetBool("isOpen", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
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
        if (collision.CompareTag("Player") && ambil)
        {
            collision.gameObject.GetComponent<PlayerHealth>().increaseMaxHealth(incMaxHealth);
            ambil = false;
        }
    }
}
