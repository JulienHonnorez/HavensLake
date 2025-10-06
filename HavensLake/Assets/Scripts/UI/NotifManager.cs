using UnityEngine;
using UnityEngine.UI;

public class NotifManager : MonoBehaviour
{
    [SerializeField] private Animator Animator;
    [SerializeField] private Image ItemImage;
    [SerializeField] private Sprite ErrorSprite;

    public void SendNotif(Sprite sprite)
    {
        if (InventoryManager.Instance.BackpackItems.Count >= 15)
            ItemImage.sprite = ErrorSprite;
        else
            ItemImage.sprite = sprite;
        Animator.SetTrigger("SendNotif");
    }
}
