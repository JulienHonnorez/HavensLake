using TMPro;
using UnityEngine;

public class Computer : MonoBehaviour
{
    [SerializeField] private GameObject ItemLinePrefab;

    [SerializeField] private GameObject InvetoryItemPrefab;
    [SerializeField] private GameObject CollectionItemPrefab;

    [SerializeField] private GameObject InventoryView;
    [SerializeField] private GameObject CollectionView;
    [SerializeField] private GameObject StoreView;
    [SerializeField] private GameObject GoalView;

    [SerializeField] private GameObject InventoryContainer;
    [SerializeField] private GameObject CollectionContainer;

    [SerializeField] private TextMeshProUGUI MoneyUI;

    private void OnEnable()
    {
        InventoryView.SetActive(false);
        CollectionView.SetActive(false);
        StoreView.SetActive(false);
        GoalView.SetActive(false);

        InventoryManager.Instance.AddItemsToInventory();

        RefreshInventory();
        RefreshCollection();

        InventoryView.SetActive(true);
    }

    public void RefreshInventory()
    {
        MoneyUI.text = $"{InventoryManager.Instance.Money}$";

        for (int i = InventoryContainer.transform.childCount - 1; i >= 0; i--)
        {
            GameObject child = InventoryContainer.transform.GetChild(i).gameObject;
            Destroy(child);
        }

        int count = 0;
        GameObject currentLine = null;
        foreach (var item in InventoryManager.Instance.InventoryItems)
        {
            if (count >= 6)
                count = 0;

            if (count == 0)
            {
                currentLine = Instantiate(ItemLinePrefab, InventoryContainer.transform);
                count++;
            }
            if (count < 6)
            {
                Instantiate(InvetoryItemPrefab, currentLine.transform).GetComponent<ItemSlot>().Setup(item);
                count++;
            }
        }
    }

    public void RefreshCollection()
    {
        MoneyUI.text = $"{InventoryManager.Instance.Money}$";

        for (int i = CollectionContainer.transform.childCount - 1; i >= 0; i--)
        {
            GameObject child = CollectionContainer.transform.GetChild(i).gameObject;
            Destroy(child);
        }

        int count = 0;
        GameObject currentLine = null;
        foreach (var item in InventoryManager.Instance.CollectionItems)
        {
            if (count >= 6)
                count = 0;

            if (count == 0)
            {
                currentLine = Instantiate(ItemLinePrefab, CollectionContainer.transform);
                count++;
            }
            if (count < 6)
            {
                Instantiate(CollectionItemPrefab, currentLine.transform).GetComponent<ItemSlot>().Setup(item);
                count++;
            }
        }
    }

    public void SwitchView(int index)
    {
        if (index == 1)
        {
            InventoryView.SetActive(true);
            CollectionView.SetActive(false);
            StoreView.SetActive(false);
            GoalView.SetActive(false);
        }
        else if (index == 2)
        {
            InventoryView.SetActive(false);
            CollectionView.SetActive(true);
            StoreView.SetActive(false);
            GoalView.SetActive(false);
        }
        else if (index == 3)
        {
            InventoryView.SetActive(false);
            CollectionView.SetActive(false);
            StoreView.SetActive(true);
            GoalView.SetActive(false);
        }
        else if (index == 4)
        {
            InventoryView.SetActive(false);
            CollectionView.SetActive(false);
            StoreView.SetActive(false);
            GoalView.SetActive(true);
        }
    }
}
