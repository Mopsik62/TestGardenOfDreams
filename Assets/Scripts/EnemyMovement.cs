using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform player; 
    public float moveSpeed = 3f; 
    private Rigidbody2D rb;
    private bool isChasing = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }

    void FixedUpdate()
    {
        if (isChasing)
        {
            MoveTowardsPlayer();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  
        {
            isChasing = true;
        }
    }

    void MoveTowardsPlayer()
    {
       
        Vector2 direction = (player.position - transform.position).normalized;

        rb.velocity = direction * moveSpeed;

        if (direction.x < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        } 
        else if (direction.x > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

    }
}
