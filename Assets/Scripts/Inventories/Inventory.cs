using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private Wallet _wallet;
    
    public Wallet wallet
    {
        get
        {
            return _wallet;
        }
    }
    public List<ItemSlot> items = new List<ItemSlot>();

    public Action<Item, int> onItemAdd;

    public Action<Item, int> onItemSubtract;

    public bool AddItem(Item item, int amount)
    {
        if (ItemExist(item))
        {
            var itemSlot = GetItemSlot(item);
            itemSlot.amount += amount;

            if(onItemAdd!= null)
            {
                onItemAdd.Invoke(item, itemSlot.amount);
            }
        }
        else
        {
            items.Add(new ItemSlot
            {
                item = item,
                amount = amount
            });

            if (onItemAdd != null)
            {
                onItemAdd.Invoke(item, amount);
            }
        }

        return true;
    }
    public bool SubtractItem(Item item, int amount)
    {
        if (ItemExist(item))
        {
            var itemSlot = GetItemSlot(item);
            itemSlot.amount -= amount;

            if(itemSlot.amount <= 0)
            {
                items.Remove(itemSlot);
            }

            if (onItemSubtract != null)
            {
                onItemSubtract.Invoke(item, itemSlot.amount);
            }

            return true;
        }
        else
        {
            return false;
        }
    }

    public bool ItemExist(Item item)
    {
        return GetItemSlot(item) != null;
    }

    public ItemSlot GetItemSlot(Item item)
    {
        foreach (var itemSlot in items)
        {
            if (itemSlot.item.Equals(item)) { return itemSlot; }
        }
        return null;
    }

    public int GetItemAmount(Item item)
    {
        var itemSlot = GetItemSlot(item);

        if(itemSlot == null) return 0;

        return itemSlot.amount;
    }
}

[System.Serializable]
public class ItemSlot
{
    public Item item;
    public int amount;
}