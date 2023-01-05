
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Graphic))]
public class InventoryItemDisplay : MonoBehaviour
{
    [SerializeField]
    private Image itemIcon;
    [SerializeField]
    private TextMeshProUGUI itemName;
    [SerializeField]
    private TextMeshProUGUI itemPrice;
    [SerializeField]
    private Button buyButton;
    [SerializeField]
    private Button sellButton;
    [SerializeField]
    private Button useButton;
    [SerializeField]
    private Button equipButton;

    [HideInInspector]
    public InventoryDisplay inventoryDisplay;
    [HideInInspector]
    public Item item;
        
    public void InitDisplay(Item item, int amount, InventoryDisplay inventoryDisplay)
    {
        this.inventoryDisplay = inventoryDisplay;
        UpdateDisplay(item, amount);
        SetDisplayMode(inventoryDisplay.displayMode);

        this.inventoryDisplay.AddInventoryAdditionListener(HandleInventoryAdd);

        this.inventoryDisplay.AddInventorySubtractionListener(HandleInventorySubtract);

        buyButton.onClick.AddListener(() =>
        {
            Shop.Instance.BuyItem(this.item, 1);
        });

        sellButton.onClick.AddListener(() =>
        {
            Shop.Instance.SellItem(this.item, 1);
        });
    }

    public void SetDisplayMode(InventoryDisplay.DisplayMode mode)
    {
        switch (mode)
        {
            case InventoryDisplay.DisplayMode.Inventory:
                buyButton.gameObject.SetActive(false);
                sellButton.gameObject.SetActive(false);
                equipButton.gameObject.SetActive(true);
                useButton.gameObject.SetActive(false);
                break;
            case InventoryDisplay.DisplayMode.Buy:
                buyButton.gameObject.SetActive(true);
                sellButton.gameObject.SetActive(false);
                equipButton.gameObject.SetActive(false);
                useButton.gameObject.SetActive(false);
                break;
            case InventoryDisplay.DisplayMode.Sell:
                buyButton.gameObject.SetActive(false);
                sellButton.gameObject.SetActive(true);
                equipButton.gameObject.SetActive(false);
                useButton.gameObject.SetActive(false);
                break;
            default:
                buyButton.gameObject.SetActive(false);
                sellButton.gameObject.SetActive(false);
                equipButton.gameObject.SetActive(true);
                break;
        }
    }

    public void UpdateDisplay(Item item, int amount)
    {
        this.item = item;
        itemIcon.sprite = item.icon;
        itemName.text = item.name + " x" + amount;
        itemPrice.text = item.price + " G";
        SetDisplayMode(inventoryDisplay.displayMode);
    }

    void HandleInventoryAdd(Item item, int amount)
    {
        if (this.item.Equals(item))
        {
            UpdateDisplay(item, amount);
        }
    }

    void HandleInventorySubtract(Item item, int amount)
    {
        if (this.item.Equals(item))
        {
            UpdateDisplay(item, amount);

            if (amount <= 0)
            {
                inventoryDisplay.RemoveDisplay(this);
                inventoryDisplay.RemoveInventoryAdditionListener(HandleInventoryAdd);
                inventoryDisplay.RemoveInventorySubtractionListener(HandleInventorySubtract);
                Destroy(gameObject);
            }
        }
    }

}
