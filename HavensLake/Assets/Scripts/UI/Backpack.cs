using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Backpack : MonoBehaviour
{
    [SerializeField] private ItemSlot SlotPrefab;

    [SerializeField] private GameObject Container1;
    [SerializeField] private GameObject Container2;
    [SerializeField] private GameObject Container3;

    private List<GameObject> Items = new List<GameObject>();

    private void OnEnable()
    {
        Reset();
        Setup();
    }

    private void Reset()
    {
        foreach (var item in Items)
            Destroy(item.gameObject);

        Items.Clear();
    }

    private void Setup()
    {
        foreach (var item in InventoryManager.Instance.BackpackItems)
        {
            var itemAdded = AddItemToContainer(item);

            if (itemAdded != null)
            {
                itemAdded.Setup(item);
                Items.Add(itemAdded.gameObject);
            }
        }
    }

    private ItemSlot AddItemToContainer(Item item)
    {
        if (Container1.transform.childCount < 5)
            return Instantiate(SlotPrefab, Container1.transform);
        if (Container2.transform.childCount < 5)
            return Instantiate(SlotPrefab, Container2.transform);
        if (Container3.transform.childCount < 5)
            return Instantiate(SlotPrefab, Container3.transform);

        return null;
    }
}
