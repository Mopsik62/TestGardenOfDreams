using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform player; 
    public float moveSpeed = 3f; 
    private Rigidbody2D rb;
    public bool isChasing = false;
    [SerializeField] private GameObject charSprite;


    void Start()
    {
        player = GameObject.Find("Character").transform; 
        rb = GetComponent<Rigidbody2D>(); 
    }

    void FixedUpdate()
    {
        if (isChasing)
        {
            MoveTowardsPlayer();
        }
    }

    public void SetChase()
    {
        isChasing = true;
    }


    void MoveTowardsPlayer()
    {
       
        Vector2 direction = (player.position - transform.position).normalized;

        rb.velocity = direction * moveSpeed;

        if (direction.x < 0)
        {
            charSprite.transform.localScale = new Vector3(-1f, 1f, 1f);
        } 
        else if (direction.x > 0)
        {
            charSprite.transform.localScale = new Vector3(1f, 1f, 1f);
        }

    }
}
