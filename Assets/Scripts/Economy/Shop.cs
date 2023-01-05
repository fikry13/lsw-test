using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField]
    private Inventory shopInventory;
    [SerializeField]
    private Inventory inventory;

    public static Shop Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void BuyItem(Item item, int amount)
    {
        var totalPrice = amount * item.price;

        if(!shopInventory.ItemExist(item) || !inventory.wallet.HasEnoughGold(totalPrice))
        {
            return;
        }

        inventory.wallet.Subtract(totalPrice);
        shopInventory.wallet.Add(totalPrice);
        shopInventory.SubtractItem(item, amount);
        inventory.AddItem(item, amount);
    }
    
    public void SellItem(Item item, int amount)
    {
        var totalPrice = amount * item.price;

        if (!inventory.ItemExist(item))
        {
            return;
        }

        inventory.wallet.Add(totalPrice);
        shopInventory.AddItem(item, amount);
        inventory.SubtractItem(item, amount);
    }
}
