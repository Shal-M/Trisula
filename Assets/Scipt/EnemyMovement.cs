using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Animator myAnim;
    private Transform target;
    public Transform homePos;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float maxrange;
    [SerializeField]
    private float minrange;

    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
        target = FindObjectOfType<PlayerMovement>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(target.position, transform.position) >= minrange && Vector3.Distance(target.position, transform.position) <= maxrange)
        {
            FollowPlayer();
        } else if(Vector3.Distance(target.position, transform.position) > maxrange)
        {
            HomePos();
        }
    }
    void FollowPlayer()
    {
        myAnim.SetBool("withRange", true);
        myAnim.SetFloat("MoveX", (target.position.x - transform.position.x));
        myAnim.SetFloat("MoveY", (target.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }
    void HomePos()
    {
        myAnim.SetFloat("MoveX", (homePos.position.x - transform.position.x));
        myAnim.SetFloat("MoveY", (homePos.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, homePos.position, speed * Time.deltaTime);

        if(Vector3.Distance(transform.position, homePos.position) == 0)
        {
            myAnim.SetBool("withRange", false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Hit")
        {
            Vector2 difference = transform.position - collision.transform.position;
            transform.position = new Vector2(transform.position. x + difference.x, transform.position.y + difference.y);
        }
    }
}
