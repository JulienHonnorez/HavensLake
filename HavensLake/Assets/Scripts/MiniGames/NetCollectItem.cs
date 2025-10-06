using UnityEngine;
using UnityEngine.UI;

public class NetCollectItem : MonoBehaviour
{
    [SerializeField] public NetCollect NetCollect;
    [SerializeField] public Item Item;
    [SerializeField] public Image Image;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Image.sprite = Item.BaseSprite;
        var scale = Random.Range(1, 2);
        this.transform.localScale = new Vector3(scale, scale, scale);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TryMe()
    {
        NetCollect.TryItem(Item);
    }
}
