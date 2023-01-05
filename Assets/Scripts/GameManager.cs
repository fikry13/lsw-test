using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }

        Instance = this;

        DontDestroyOnLoad(this);
    }

    public PlayerController playerController;

    public InventoryDisplay inventoryDisplay;

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    public void SetPlayerInput(bool canInput)
    {
        playerController.SetPlayerInput(canInput);
    }

    public void ToggleInventory()
    {
        bool toggle = !inventoryDisplay.gameObject.activeSelf;
        inventoryDisplay.SetMode(InventoryDisplay.DisplayMode.Inventory);
        inventoryDisplay.gameObject.SetActive(toggle);
    }
}
