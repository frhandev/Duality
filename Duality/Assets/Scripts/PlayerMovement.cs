using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [Header("Run")]
    [SerializeField] private float playerSpeed;
    [SerializeField] private float maxRotaion;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    private float rotation;

    private bool isFacingRight = true;

    [Header("Jump")]
    [SerializeField] private AudioSource jumpSFX;
    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float fallMultiplayer;
    [SerializeField] private float jumpTime;
    [SerializeField] private float jumpMultiplayer;
    [SerializeField] private float coyoteTime = 0.2f;
    [SerializeField] private float jumpBufferTime = 0.2f;
    [SerializeField] private ParticleSystem jumpDust;
    private bool isGrounded;
    private bool isJumping;
    private float jumpTimeCounter;
    private float coyoteTimeCounter;
    private float jumpBufferCounter;
    private Vector2 vecGravity;

    private void Start()
    {
        vecGravity = new Vector2(0, -Physics2D.gravity.y);
        coyoteTimeCounter = 0;
    }


    void Update()
    {
        //Check Ground
        isGrounded = Physics2D.OverlapCapsule(groundCheck.position, new Vector2(0.99f, 0.3f), CapsuleDirection2D.Horizontal, 0, groundLayer);
    
        //Jump
        if (Input.GetButtonDown("Jump"))
        {
            coyoteTimeCounter = coyoteTime;
        }
        coyoteTimeCounter -= Time.deltaTime;

        if(isGrounded)
        {
            jumpBufferCounter = jumpBufferTime;
        }
        else
        {
            jumpBufferCounter-= Time.deltaTime;
        }

        if (jumpBufferCounter > 0 && coyoteTimeCounter > 0 && jumpTimeCounter >= 0)
        {
            jumpBufferCounter = 0;
            rb.velocity = new Vector2 (rb.velocity.x, jumpForce);
            isJumping = true;
            jumpTimeCounter = 0;
            animator.SetTrigger("Jump");
            jumpDust.Play();
            jumpSFX.Play();
        }

        if(rb.velocity.y > 0 && isJumping)
        {
            jumpTimeCounter += Time.deltaTime;
            if(jumpTimeCounter >= jumpTime) isJumping = false;

            float t = jumpTimeCounter / jumpMultiplayer;
            float currentJumpM = jumpMultiplayer;

            if (t>0.5f)
            {
                currentJumpM = jumpMultiplayer * (1 - t);
            }

            rb.velocity += vecGravity * currentJumpM * Time.deltaTime;
        }

        if (Input.GetButtonUp("Jump"))
        {
            coyoteTimeCounter = 0;
            jumpBufferCounter = 0;
            isJumping = false;
            jumpTimeCounter = 0;

            if(rb.velocity.y > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.6f);
            }
        }

        //fall Mutliplayer
        if(rb.velocity.y < 0f)
        {
            rb.velocity -= vecGravity * fallMultiplayer * Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        float movement = Input.GetAxis("Horizontal") * playerSpeed;
        rb.velocity = new Vector2(movement, rb.velocity.y);

        if(movement > 0 && !isFacingRight)
        {
            Flip();
        }

        if (movement < 0 && isFacingRight)
        {
            Flip();
        }

        //Game Feel
        if(Mathf.Abs(rb.velocity.x) > 0)
        {
            if(isFacingRight)
            {
                transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, maxRotaion);
            }
                else
            {
                transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, -maxRotaion);
            }
        }
        else
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0);
        }
    }

    void Flip()
    {
        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;
        animator.SetTrigger("Flip");
    }
}
