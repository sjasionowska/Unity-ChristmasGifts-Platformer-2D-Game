using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SantaMovement : MonoBehaviour
{
    [SerializeField]
    float MaxSpeed = 10.0f;

    [SerializeField]
    float JumpForce = 700.0f;

    bool onGround = false;
    public Transform GroundCheck;

    [SerializeField]
    float groundRadius = 0.3f;
    public LayerMask WhatIsGround;

    Animator anim;

    bool facingRight = true;

    float move;

    Rigidbody2D rb;

    Vector2 JumpVector;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        JumpVector = new Vector2(0, JumpForce);
    }

    void FixedUpdate()
    {
        onGround = Physics2D.OverlapCircle(GroundCheck.position, groundRadius, WhatIsGround);
        anim.SetBool("Ground", onGround);

        anim.SetFloat("vSpeed", rb.velocity.y);

        move = Input.GetAxis("Horizontal");

        anim.SetFloat("Speed", Mathf.Abs(move));

        rb.velocity = new Vector2(move * MaxSpeed, rb.velocity.y);

        if (move > 0 && !facingRight)
            Flip();
        else if (move < 0 && facingRight)
            Flip();

        if (onGround && Input.GetAxis("Jump") > 0)
        {
            anim.SetBool("Ground", false);
            rb.velocity = new Vector2(move * MaxSpeed, JumpForce);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!onGround)
            rb.velocity = new Vector2(0, rb.velocity.y);
    }


    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
