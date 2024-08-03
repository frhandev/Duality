using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float enemySpeed = 3.0f;
    [SerializeField] private Animator animator;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Transform[] limits;

    bool isFacingRight = true;

    private void Update()
    {
        if(Mathf.Abs(transform.position.x - limits[0].position.x) <= 0.2f && isFacingRight)
        {
            Flip();
        } 
        else if(Mathf.Abs(transform.position.x - limits[1].position.x) <= 0.2f && !isFacingRight)
        {
            Flip();
        }
    }

    void FixedUpdate()
    {
        rb.velocity = transform.right *enemySpeed;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerMovement>() != null)
        {
            gameManager.Died();
        }
    }

    void Flip()
    {
        enemySpeed *= -1;
        animator.SetTrigger("Flip");
        isFacingRight = !isFacingRight;
    }
}
