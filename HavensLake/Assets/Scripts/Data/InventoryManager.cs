using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] public int Money = 0;

    [SerializeField] public List<Item> BackpackItems = new List<Item>();
    [SerializeField] public List<Item> InventoryItems = new List<Item>();
    [SerializeField] public List<Item> CollectionItems = new List<Item>();

    // Singleton
    private static InventoryManager instance;
    public static InventoryManager Instance { get { return instance; } }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public void TryAddItemToBackpack(Item item)
    {
        if (BackpackItems.Count < 15)
        {
            item.Setup();
            BackpackItems.Add(item);
        }
    }

    public void AddItemsToInventory()
    {
        InventoryItems.AddRange(BackpackItems);
        InventoryItems = InventoryItems.OrderBy(x => x.GetName()).ToList();

        BackpackItems.Clear();
    }

    public bool TrySellItem(Guid itemId)
    {
        var itemToSell = InventoryItems.FirstOrDefault(x => x.Id == itemId);

        if(itemToSell == null) return false;

        InventoryItems.Remove(itemToSell);
        Money += itemToSell.SellValue;

        return true;
    }
    public bool TryRestoreItem(Guid itemId)
    {
        var itemToRestore = InventoryItems.FirstOrDefault(x => x.Id == itemId);

        if (itemToRestore == null) return false;
        if (itemToRestore.RestoreCost > Money) return false;

        InventoryItems.Remove(itemToRestore);
        CollectionItems.Add(itemToRestore);
        Money -= itemToRestore.RestoreCost;

        GameObject.FindGameObjectWithTag("GoalManager").GetComponent<GoalManager>().CheckIfGoalReached(itemToRestore);

        return true;
    }

    public bool TryBuyItem(Item item)
    {
        if (item.RestoreCost > Money) return false;

        Money -= item.RestoreCost;
        GameObject.FindGameObjectWithTag("GoalManager").GetComponent<GoalManager>().CheckIfGoalReached(item);
        return true;
    }
}
