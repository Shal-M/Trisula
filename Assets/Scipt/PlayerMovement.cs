using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D myRigidBody;
    private Animator myAnim;

    private float attackTime = .35f;
    private float attackCounter = .35f;
    private bool isAttack;
    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (movement != Vector2.zero)
        {
            myAnim.SetBool("iswalking", true);
            myAnim.SetFloat("MoveX", movement.x);
            myAnim.SetFloat("MoveY", movement.y);
        }
        else
        {
            myAnim.SetBool("iswalking", false);
        }
        myRigidBody.MovePosition(myRigidBody.position + movement * Time.deltaTime * speed);
        if (isAttack)
        {
            attackCounter -= Time.deltaTime;
            if(attackCounter <= 0)
            {
                myAnim.SetBool("attack", false);
                isAttack = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            attackCounter = attackTime;
            myAnim.SetBool("attack", true);
            isAttack = true;
        }
    }
}
