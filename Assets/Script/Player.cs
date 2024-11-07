using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float maxSpeed;
    private Rigidbody2D rigid;
    private Animator playerAnimator;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);
        if (rigid.velocity.x > maxSpeed) // right max speed
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        }
        else if (rigid.velocity.x < maxSpeed * (-1))// left max speed
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);
        }
        if (rigid.velocity.x != 0)
        {
            playerAnimator.SetBool("IsRuning", true);
        }
        else
        {
            playerAnimator.SetBool("IsRuning", false);
        }
    }
}
