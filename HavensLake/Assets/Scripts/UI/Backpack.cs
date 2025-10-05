using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Backpack : MonoBehaviour
{
    [SerializeField] private ItemSlot SlotPrefab;

    [SerializeField] private GameObject Container1;
    [SerializeField] private GameObject Container2;
    [SerializeField] private GameObject Container3;

    private void OnDisable()
    {
        ResetMe();
    }

    private void OnEnable()
    {
        Setup();
    }

    private void ResetMe()
    {
        for (int i = Container1.transform.childCount - 1; i >= 0; i--)
        {
            GameObject child = Container1.transform.GetChild(i).gameObject;
            Destroy(child);
        }
        for (int i = Container2.transform.childCount - 1; i >= 0; i--)
        {
            GameObject child = Container2.transform.GetChild(i).gameObject;
            Destroy(child);
        }
        for (int i = Container3.transform.childCount - 1; i >= 0; i--)
        {
            GameObject child = Container3.transform.GetChild(i).gameObject;
            Destroy(child);
        }
    }

    private void Setup()
    {
        foreach (var item in InventoryManager.Instance.BackpackItems)
        {
            var itemAdded = AddItemToContainer(item);

            if (itemAdded != null)
            {
                itemAdded.Setup(item);
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
