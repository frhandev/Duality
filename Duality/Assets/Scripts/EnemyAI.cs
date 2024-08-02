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

    private void OnTriggerExit2D(Collider2D collision)
    {
        Flip();
    }

    void Flip()
    {
        transform.Rotate(0, 180, 0);
        animator.SetTrigger("Flip");
    }
}
