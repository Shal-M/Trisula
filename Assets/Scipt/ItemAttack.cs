using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemAttack : MonoBehaviour
{
    public GameObject dialogBox;
    public Text dialogText;
    public string dialog;
    public bool inRange;
    public int counter=0;
    [SerializeField]
    private int incAtk;
    private PlayerAttack attack;
    public bool ambil;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K) && inRange)
        {
            if (!ambil)
            {
                //dialogBox.SetActive(true);
                //dialogText.text = dialog;
                //anim.SetBool("isOpen", true);
                ambil = true;
            }
            else
            {
                dialogBox.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")){
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && ambil)
        {
            //collision.gameObject.GetComponent<PlayerAttack>().increaseAttack(incAtk);
            ambil = false;
        }
    }
}
