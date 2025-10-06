using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class NetCollect : MonoBehaviour
{
    [SerializeField] private MoveManager MoveManager;
    [SerializeField] private List<Item> AllowedItems = new List<Item>();
    [SerializeField] private List<Image> ObjectivesList = new List<Image>();
    [SerializeField] private List<GameObject> ObjectivesValidateList = new List<GameObject>();
    [SerializeField] private List<GameObject> ErrorsList = new List<GameObject>();
    [SerializeField] private List<GameObject> Points = new List<GameObject>();
    [SerializeField] private GameObject ItemPrefab;

    private List<GameObject> GeneratedItems = new List<GameObject>();
    private List<Item> ItemsToFind = new List<Item>();
    private List<Item> ItemsFound = new List<Item>();
    private int SuccessCount = 0;
    private int ErrorCount = 0;

    private void OnEnable()
    {
        SuccessCount = 0;
        ErrorCount = 0;
        GeneratedItems = new List<GameObject>();
        ItemsFound = new List<Item>();
        ItemsToFind = new List<Item>();
        List<Item> generatedItemsItems = new List<Item>();

        foreach (var tmp in ErrorsList)
            tmp.SetActive(false);
        foreach (var tmp in ObjectivesValidateList)
            tmp.SetActive(false);

        List<int> generateIndexes = new List<int>();
        for (int i = 0; i < 10; i++)
        {
            var itemIndex = Random.Range(0, AllowedItems.Count);
            var itemObject = Instantiate(ItemPrefab, Points[i].transform);
            itemObject.GetComponent<NetCollectItem>().Item = AllowedItems[itemIndex];
            itemObject.GetComponent<NetCollectItem>().NetCollect = this;
            generatedItemsItems.Add(AllowedItems[itemIndex]);
            GeneratedItems.Add(itemObject);
        }

        generateIndexes = new List<int>();
        for (int i = 0; i < 3; i++)
        {
            var itemIndex = -1;

            do
            {
                itemIndex = Random.Range(0, GeneratedItems.Count);
            } while (generateIndexes.Contains(itemIndex));
            generateIndexes.Add(itemIndex);

            ObjectivesList[i].sprite = generatedItemsItems[itemIndex].BaseSprite;
            ItemsToFind.Add(generatedItemsItems[itemIndex]);
        }
    }

    private void OnDisable()
    {
        foreach (var item in GeneratedItems)
            Destroy(item.gameObject);
    }

    public void TryItem(Item item)
    {
        var itemToFindCount = ItemsToFind.Count(x => x.NameFR == item.NameFR);

        if (itemToFindCount > 0)
        {
            var itemFoundCount = ItemsFound.Count(x => x.NameFR == item.NameFR);

            if (itemFoundCount < itemToFindCount)
            {
                //win
                InventoryManager.Instance.TryAddItemToBackpack(item);
                ItemsFound.Add(item);
                SuccessCount++;

                var validateIndex = -1;
                for (int index = 0; index < ObjectivesValidateList.Count; index++)
                {
                    if (!ObjectivesValidateList[index].activeSelf && ItemsToFind[index].NameFR == item.NameFR)
                    {
                        ObjectivesValidateList[index].SetActive(true);
                        break;
                    }
                }
            }
            else
            {
                //loose
                ErrorCount++;
                ErrorsList[ErrorCount - 1].SetActive(true);
            }
        }
        else
        {
            //loose
            ErrorCount++;
            ErrorsList[ErrorCount - 1].SetActive(true);
        }

        if (ErrorCount == 3)
            MoveManager.Navigate(10);
        else if (SuccessCount == 3)
            StartCoroutine(Unload());
    }

    public IEnumerator Unload()
    {
        yield return new WaitForSeconds(2);
        MoveManager.Navigate(10);
    }
}
