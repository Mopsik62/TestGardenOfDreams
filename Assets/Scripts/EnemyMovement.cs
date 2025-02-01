using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyMovement : MonoBehaviour
{
    public Transform player; 
    public float moveSpeed = 3f; 
    private Rigidbody2D rb;
    public bool isChasing = false;
    private int lastDirection = 1; // 1 Ч направо, -1 Ч налево
    [SerializeField] private GameObject charSprite;
    [SerializeField] private Transform frontLegs;
    [SerializeField] private Transform backLegs;



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
        if (isChasing)
            return;
        isChasing = true;

    }


    void MoveTowardsPlayer()
    {

        Vector2 direction = (player.position - transform.position).normalized;

        rb.velocity = direction * moveSpeed;

        int currentDirection = direction.x < 0 ? -1 : 1;

        if (currentDirection != lastDirection)
        {
            charSprite.transform.localScale = new Vector3(currentDirection, 1f, 1f);
 

            lastDirection = currentDirection; // ќбновл€ем текущее направление
        }

    }
}
