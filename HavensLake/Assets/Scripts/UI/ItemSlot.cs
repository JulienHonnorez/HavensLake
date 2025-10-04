using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [SerializeField] public Item Item;
    [SerializeField] public TextMeshProUGUI TitleUI;
    [SerializeField] public Image Renderer;
    [SerializeField] public GameObject RestoreButton;
    [SerializeField] public GameObject SellButton;
    [SerializeField] public bool IsBackpackSlot;
    [SerializeField] public bool IsInventorySlot;
    [SerializeField] public bool IsCollectionSlot;
    [SerializeField] public bool IsShopSlot;

    private bool Bought;
    private Computer computer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        computer = GameObject.FindGameObjectWithTag("Computer").GetComponent<Computer>();

        if (IsShopSlot)
            Setup(Item);
    }

    // Update is called once per frame
    void Update()
    {
        if (computer == null)
            computer = GameObject.FindGameObjectWithTag("Computer").GetComponent<Computer>();
    }

    public void Setup(Item item)
    {
        Item = item;

        if (IsBackpackSlot)
            SetupBackpackSlot();
        else if (IsInventorySlot)
            SetupInventorySlot();
        else if (IsCollectionSlot)
            SetupCollectionSlot();
        else if (IsShopSlot)
            SetupShopSlot();
    }

    private void SetupBackpackSlot()
    {
        TitleUI.text = Item.GetName();
        Renderer.sprite = Item.BaseSprite;
    }

    private void SetupInventorySlot()
    {
        TitleUI.text = Item.GetName();
        Renderer.sprite = Item.BaseSprite;

        RestoreButton.SetActive(false);
        SellButton.SetActive(false);

        var label = SettingsManager.Instance.IsGameInFrench() ? "Restaurer" : "Restore";
        RestoreButton.GetComponentInChildren<TextMeshProUGUI>().text = $"Restaurer ({Item.RestoreCost}$)";
        label = SettingsManager.Instance.IsGameInFrench() ? "Vendre" : "Sell";
        SellButton.GetComponentInChildren<TextMeshProUGUI>().text = $"Vendre ({Item.SellValue}$)";
    }

    private void SetupShopSlot()
    {
        TitleUI.text = Item.GetName();
        Renderer.sprite = Item.BaseSprite;

        if (Item.CanBeRestored)
            RestoreButton.SetActive(false);
        SellButton.SetActive(false);

        var label = SettingsManager.Instance.IsGameInFrench() ? "Acheter" : "Buy";
        SellButton.GetComponentInChildren<TextMeshProUGUI>().text = $"{label} ({Item.RestoreCost}$)";
    }

    private void SetupCollectionSlot()
    {
        TitleUI.text = Item.GetRestoredName();
        Renderer.sprite = Item.RestoredSprite;
    }

    private void OnMouseOver()
    {
        if (Item.CanBeRestored)
            RestoreButton.SetActive(true);
        if (!Bought)
            SellButton.SetActive(true);
    }

    private void OnMouseExit()
    {
        if (Item.CanBeRestored)
            RestoreButton.SetActive(false);

        SellButton.SetActive(false);
    }

    public void RestoreItem()
    {
        var resultStatus = InventoryManager.Instance.TryRestoreItem(Item.Id);

        if (resultStatus)
        {
            computer.RefreshInventory();
            computer.RefreshCollection();
        }
    }

    public void SellItem()
    {
        var resultStatus = InventoryManager.Instance.TrySellItem(Item.Id);

        if (resultStatus)
            computer.RefreshInventory();
    }

    public void BuyItem()
    {
        Bought = InventoryManager.Instance.TryBuyItem(Item);

        if (Bought)
        {
            TitleUI.text = SettingsManager.Instance.IsGameInFrench() ? "Livraison en cours" : "Delivery in progress";
            SellButton.SetActive(false);
            computer.RefreshInventory();
        }
    }
}
