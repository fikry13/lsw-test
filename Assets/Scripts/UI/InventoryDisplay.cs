using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryDisplay : MonoBehaviour
{
    [SerializeField]
    private List<InventoryItemDisplay> itemDisplays = new List<InventoryItemDisplay>();

    [SerializeField]
    private Inventory inventory;

    [SerializeField]
    private RectTransform itemDisplayParent;

    [SerializeField]
    private InventoryItemDisplay inventoryItemDisplayPrefab;

    private DisplayMode _displayMode;

    public DisplayMode displayMode
    {
        get
        {
            return _displayMode;
        }
        set
        {
            SetMode(value);
        }
    }

    private void Start()
    {
        inventory.onItemAdd += (item, amount) =>
        {
            bool exist = false;
            foreach(var itemDisplay in itemDisplays)
            {
                if (itemDisplay.item.id.Equals(item.id))
                {
                    exist = true;
                }
            }
            Debug.Log("Exist : " + exist + "n " + "test".Equals(item.id));
            if (!exist)
            {
                AddNewItem(new ItemSlot
                {
                    item = item,
                    amount = amount
                });
            }
        };

        InitInventoryDisplay();
    }

    public void SetMode(DisplayMode displayMode)
    {
        _displayMode = displayMode;
        foreach (var itemDisplay in itemDisplays)
        {
            itemDisplay.SetDisplayMode(displayMode);
        }
    }

    public void ShowInventoryDisplay(bool show)
    {
        gameObject.SetActive(show);
    }

    public void InitInventoryDisplay()
    {
        foreach(ItemSlot itemSlot in inventory.items)
        {
            if (itemSlot != null && itemSlot.item != null)
            {
                AddNewItem(itemSlot);
            }
        }
    }

    public void AddNewItem(ItemSlot itemSlot)
    {
        InventoryItemDisplay newItemDisplay = Instantiate(inventoryItemDisplayPrefab, itemDisplayParent).GetComponent<InventoryItemDisplay>();
        newItemDisplay.InitDisplay(itemSlot.item, itemSlot.amount, this);
        itemDisplays.Add(newItemDisplay);
    }

    public void RemoveDisplay(InventoryItemDisplay inventoryItemDisplay)
    {
        itemDisplays.Remove(inventoryItemDisplay);
    }

    public void AddInventoryAdditionListener(Action<Item, int> action)
    {
        inventory.onItemAdd += action;
    }

    public void RemoveInventoryAdditionListener(Action<Item, int> action)
    {
        inventory.onItemAdd -= action;
    }

    public void AddInventorySubtractionListener(Action<Item, int> action)
    {
        inventory.onItemSubtract += action;
    }

    public void RemoveInventorySubtractionListener(Action<Item, int> action)
    {
        inventory.onItemSubtract -= action;
    }

    public enum DisplayMode
    {
        Inventory,
        Buy,
        Sell
    }
}
