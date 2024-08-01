using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float playerSpeed;
    [SerializeField] private Rigidbody2D rb;

    private bool isFacingRight = true;
    private bool isGrounded = true;


    void Update()
    {

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
    }

    void Flip()
    {
        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;
    }
}
