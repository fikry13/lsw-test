
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

        this.inventoryDisplay.AddInventoryAdditionListener(HandleInventoryAdd);

        this.inventoryDisplay.AddInventorySubtractionListener(HandleInventorySubtract);

        buyButton.onClick.AddListener(() =>
        {

        });

        sellButton.onClick.AddListener(() =>
        {

        });

        useButton.onClick.AddListener(() =>
        {

        });

        equipButton.onClick.AddListener(() =>
        {

        });
    }

    public void UpdateDisplay(Item item, int amount)
    {
        this.item = item;
        itemIcon.sprite = item.icon;
        itemName.text = item.name + " x" + amount;
        itemPrice.text = item.price + " G";
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
