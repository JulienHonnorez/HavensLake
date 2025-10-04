using System;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] public Guid Id;
    [SerializeField] public string NameFR;
    [SerializeField] private string NameEN;
    [SerializeField] private string RestoredNameFR;
    [SerializeField] private string RestoredNameEN;
    [SerializeField] public int SellValue;
    [SerializeField] public int RestoreCost;
    [SerializeField] public Sprite BaseSprite;
    [SerializeField] public Sprite RestoredSprite;
    [SerializeField] public bool CanBeRestored;
    [SerializeField] public bool IsNarrativeElement;
    [SerializeField] public int NarrativeId;

    public void Setup()
    {
        Id = Guid.NewGuid();
    }

    public string GetName()
    {
        return SettingsManager.Instance.IsGameInFrench() ? NameFR : NameEN;
    }

    public string GetRestoredName()
    {
        return SettingsManager.Instance.IsGameInFrench() ? RestoredNameFR : RestoredNameEN;
    }
}
