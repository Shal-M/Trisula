using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestoreHealth : MonoBehaviour
{
    public GameObject dialogBox;
    public Text dialogText;
    public string dialog;
    public bool inRange;
    public bool restore;
    public PlayerHealth stat;
    // Start is called before the first frame update
    void Start()
    {
        dialogBox.SetActive(false);
        stat = GameObject.Find("player").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K) && inRange && !restore)
        {
            dialogBox.SetActive(true);
            dialogText.text = dialog;
            stat.restoreHealth();
            restore = true;
        } else if (Input.GetKeyDown(KeyCode.K) && inRange && restore)
        {
            dialogBox.SetActive(false);
            restore = false;
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
    }
}
