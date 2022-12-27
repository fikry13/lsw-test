using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public ItemSlot[] items = new ItemSlot[10];

    public bool AddItem(Item item, int amount)
    {
        if (ItemExist(item))
        {
            GetItemSlot(item).amount += amount;
        }
        else
        {
            if (!IsSlotAvailable())
            {
                return false;
            }

            int index = GetAvailableSlot();

            items[index] = new ItemSlot
            {
                item = item,
                amount = amount
            };
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
                items[GetItemIndex(item)] = null;
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
        foreach (var slot in items)
        {
            if (slot.item != null && slot.item.Equals(item))
            {
                return slot;
            }
        }
        return null;
    }

    public int GetItemIndex(Item item)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i].item != null && items[i].item.Equals(item))
            {
                return i;
            }
        }
        return -1;
    }

    public int GetAvailableSlot()
    {
        for(int i = 0; i < items.Length; i++)
        {
            if (items[i] == null || items[i].item == null)
            return i;
        }

        return -1;
    }

    public bool IsSlotAvailable()
    {
        return GetAvailableSlot() != -1;
    }
}

[System.Serializable]
public class ItemSlot
{
    public Item item;
    public int amount;
}