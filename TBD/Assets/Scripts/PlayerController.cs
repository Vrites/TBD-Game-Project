using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;                 //Public variables with no declaration can be changed inside Unity Inspector
    public float jumpForce;

    public KeyCode left;                    //TODO: Assign each keycode for each player in Unity
    public KeyCode right;
    public KeyCode jump;
    public KeyCode shoot;                   //TODO: Use "keycode shoot" to make players shoot projectiles

    private Rigidbody2D rb;

    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask whatIsGround;

    public bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGround);

        //Movement

        if (Input.GetKey(left))
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        } else if (Input.GetKey(right))
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }else
        {
            rb.velocity = new Vector2(0f, rb.velocity.y);
        }

        if (Input.GetKeyDown(jump) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        //This flips the player so that the player is facing the way it is moving

        if(rb.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        } else if(rb.velocity.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
