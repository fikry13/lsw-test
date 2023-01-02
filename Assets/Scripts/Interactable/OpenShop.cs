using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenShop : Interactable
{
    [SerializeField]
    private InventoryDisplay shopInventoryDisplay;
    [SerializeField]
    private InventoryDisplay inventoryDisplay;

    public override void Interact()
    {
        base.Interact();

        if (!inventoryDisplay.gameObject.activeSelf)
        {
            inventoryDisplay.gameObject.SetActive(true);
            inventoryDisplay.displayMode = InventoryDisplay.DisplayMode.Sell;
        }
        if (!shopInventoryDisplay.gameObject.activeSelf)
        {
            shopInventoryDisplay.gameObject.SetActive(true);
            shopInventoryDisplay.displayMode = InventoryDisplay.DisplayMode.Buy;
        }

    }
}
