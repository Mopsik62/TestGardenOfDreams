using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Vector2 move;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
        Debug.Log(move);

    }

    void Update()
    {
        movePlayer();
    }
    public void movePlayer()
    {
        Vector2 movement = speed * Time.fixedDeltaTime * move;
        rb.MovePosition(rb.position + movement);
        Debug.Log(move);
    }

}
