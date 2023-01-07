using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public PlayerAction playerAction;
    public Inventory inventory;

    public bool canInput;

    private void Update()
    {
        if (canInput)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                GameManager.Instance.ToggleInventory();
            }
        }

        RotateAction();
    }

    public void SetPlayerInput(bool canInput)
    {
        playerAction.canAct = canInput;
        playerMovement.canMove = canInput;
    }

    private void RotateAction()
    {
        var idle = playerMovement.rigidbody2d.velocity == Vector2.zero;

        var velocity = playerMovement.rigidbody2d.velocity;

        if (velocity.x < 0 || velocity.y < 0)
        {
            if (velocity.x < velocity.y)
            {
                playerAction.transform.rotation = Quaternion.Euler(0, 0, -90);
            }
            else
            {
                playerAction.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
        else if (velocity.x > 0 || velocity.y > 0)
        {
            if (velocity.x > velocity.y)
            {
                playerAction.transform.rotation = Quaternion.Euler(0, 0, 90);
            }
            else
            {
                playerAction.transform.rotation = Quaternion.Euler(0, 0, 180);
            }
        }
    }
}
