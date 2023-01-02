using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField]
    private Inventory shopInventory;
    [SerializeField]
    private Inventory inventory;

    public ItemSlot BuyItem(Item item, int amount)
    {
        if(!shopInventory.ItemExist(item))
        {
            return null;
        }
        else
        {
            return shopInventory.GetItemSlot(item);
        }
    }
    
    public void SellItem(Item item, int amount)
    {
        shopInventory.AddItem(item, amount);
    }
}
