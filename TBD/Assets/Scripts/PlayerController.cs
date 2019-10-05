﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;                 //Public variables with no declaration can be changed inside Unity Inspector
    public float jumpForce;
    public float rSpeed;

    public int health = 100;

    private bool isFacingRight;

    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;
    public KeyCode aimUp;
    public KeyCode aimDown;

    private Rigidbody2D rb;

    public GameObject player;

    public Transform arms;
    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask whatIsGround;

    public bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        arms = this.gameObject.transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGround);

        //Movement

        if (Input.GetKey(left))
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }
        else if (Input.GetKey(right))
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0f, rb.velocity.y);
        }
        if (Input.GetKeyDown(jump) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        //This flips the player and its children which is important for the raycast

        if(rb.velocity.x > 0 && isFacingRight)
        {
            isFacingRight = !isFacingRight;
            transform.Rotate(0, 180f, 0);
        } else if(rb.velocity.x < 0 && !isFacingRight)
        {
            isFacingRight = !isFacingRight;
            transform.Rotate(0, 180f, 0);
        }

        if (Input.GetKey(aimUp))
        {
            arms.transform.Rotate(new Vector3(0, 0, rSpeed) * Time.deltaTime);
        }
        else if (Input.GetKey(aimDown))
        {
            arms.transform.Rotate(new Vector3(0, 0, -rSpeed) * Time.deltaTime);
        }
    }

    public void TakeDamage (int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
