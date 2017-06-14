using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player Settings")]
    public float maxSpeed = 10f;
    public float jumpForce = 400f;
    [Range(0, 1)]
    public float crouchSpeed = 0.3f;
    public bool airControl = false;
    public LayerMask whatIsGround;

    private bool facingRight = true;
    private Transform groundCheck;
    private float groundRadius = 0.2f;
    private bool grounded = false;
    private Transform ceilingCheck;
    private float ceilingRadius = 0.01f;
    private Animator anim;
    private Rigidbody2D rigid;
    // Use this for initialization
    void Start()
    {
        groundCheck = transform.Find("GroundCheck");
        ceilingCheck = transform.Find("CeilingCheck");
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Check if the player is grounded
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

        anim.SetBool("Ground", grounded);

        anim.SetFloat("VSpeed", rigid.velocity.y);
    }

    void Flip()
    {
        // Switch the way the player is facing
        facingRight = !facingRight;

        // Flip the players scale on x
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    public void Move(float move, bool crouch, bool jump)
    {
        // If crouching,then check to see if player can stand up
        if (!crouch && anim.GetBool("Crouch"))
        {
            if (Physics2D.OverlapCircle(ceilingCheck.position, ceilingRadius, whatIsGround)) 
            {
                crouch = true;
            }
        }

        anim.SetBool("Crouch", crouch);
        // Only control the player is grounded or airControl is turned on
        if (grounded || airControl)
        {
            // Replace the speed if crouching by the crouchSpeed
            move = (crouch ? move * crouchSpeed : move);

            anim.SetFloat("Speed", Mathf.Abs (move));

            // Move the character
            rigid.velocity = new Vector2(move * maxSpeed, rigid.velocity.y);

            if (move > 0 && !facingRight)
            {
                Flip();
            }
            else if (move < 0 && facingRight)
            {
                Flip();
            }
        }

        if (grounded && jump && anim.GetBool ("Ground"))
        {
            grounded = false;
            anim.SetBool("Ground", false);
            rigid.AddForce(new Vector2(0f, jumpForce));
        }
    }
}
