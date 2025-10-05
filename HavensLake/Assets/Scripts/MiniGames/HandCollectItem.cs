using UnityEngine;

public class HandCollectItem : MonoBehaviour
{
    [SerializeField] public Item Item;

    public void TryCollectItem()
    {
        GameObject.FindGameObjectWithTag("SoundPlayer").GetComponent<SoundPlayer>().PlayHandWater();
        InventoryManager.Instance.TryAddItemToBackpack(Item);
        Destroy(this.gameObject);
    }

    public void DestroyMe()
        => Destroy(this.gameObject);
}
