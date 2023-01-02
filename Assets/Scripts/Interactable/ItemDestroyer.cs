using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDestroyer : Interactable
{
    public Item item;
    public int amount;

    public override void Interact()
    {
        bool removed = GameManager.Instance.playerController.inventory.SubtractItem(item, amount);

        Debug.Log(removed);
    }
}
