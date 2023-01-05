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
    }

    public void SetPlayerInput(bool canInput)
    {
        playerAction.canAct = canInput;
        playerMovement.canMove = canInput;
    }
}
