using UnityEngine;
using UnityEngine.UI;

public class NotifManager : MonoBehaviour
{
    [SerializeField] private Animator Animator;
    [SerializeField] private Image ItemImage;

    public void SendNotif(Sprite sprite)
    {
        ItemImage.sprite = sprite;
        Animator.SetTrigger("SendNotif");
    }
}
