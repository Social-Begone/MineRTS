using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMovement : MonoBehaviour
{

    public float moveSpeed = 5f;
    public bool isSelected = false;

    public Rigidbody2D rb;

    Vector2 movement;
    Vector2 direction;
    Vector3 mouse;

    void Start()
    {
        mouse.x = rb.position.x;
        mouse.y = rb.position.y;
    }
    void Update()
    {
        

        if (Input.GetButtonDown("Fire1") && isSelected)
        {
            isSelected = false;
            mouse = Input.mousePosition;
            mouse = Camera.main.ScreenToWorldPoint(mouse);

            direction = new Vector2(
            mouse.x - transform.position.x,
            mouse.y - transform.position.y
            );

            transform.right = direction;

        }

        if (rb.position.x < mouse.x - 1)
        {
            movement.x = 1;
        }
        else if (rb.position.x > mouse.x + 1)
        {
            movement.x = -1;
        }
        else
        {
            movement.x = 0;
        }
        if (rb.position.y < mouse.y - 1)
        {
            movement.y = 1;
        }
        else if (rb.position.y > mouse.y + 1)
        {
            movement.y = -1;
        }
        else
        {
            movement.y = 0;
        }

    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
