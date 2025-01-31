using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Vector2 move;
    private Rigidbody2D rb;
    [SerializeField] private GameObject charSprite;



    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
        //Debug.Log(move);

    }

    void LateUpdate()
    {
        movePlayer();
    }
    public void movePlayer()
    {
        Vector2 movement = speed * move;
        rb.velocity = movement;
        if (movement.x < 0)
        {
            charSprite.transform.localScale = new Vector3(-1f, 1f, 1f); // Зеркалим по оси X
        }
        else if (movement.x > 0)
        {
            charSprite.transform.localScale = new Vector3(1f, 1f, 1f); // Оставляем спрайт без зеркала
        }
       // Debug.Log(move);
    }

}
