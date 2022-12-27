using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public bool canMove;

    Rigidbody2D rigidbody2d;

    private void Awake()
    {
        rigidbody2d= GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        var velocityX = Input.GetAxis("Horizontal") * speed;
        var velocityY = Input.GetAxis("Vertical") * speed;

        rigidbody2d.velocity = new Vector2(velocityX, velocityY);
    }
}
