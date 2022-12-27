using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDispenser : Interactable
{
    public Item item;
    public int amount;

    public override void Interact()
    {
        bool added = GameManager.Instance.playerController.inventory.AddItem(item, amount);

        Debug.Log(added);
    }
}
