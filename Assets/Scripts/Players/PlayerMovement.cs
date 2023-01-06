using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public bool canMove;

    public Rigidbody2D rigidbody2d;

    private void Awake()
    {
        rigidbody2d= GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (canMove)
        {
            var velocityX = Input.GetAxisRaw("Horizontal") * speed;
            var velocityY = Input.GetAxisRaw("Vertical") * speed;

            rigidbody2d.velocity = new Vector2(velocityX, velocityY);
        }
    }
}
