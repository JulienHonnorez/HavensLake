using UnityEngine;
using UnityEngine.UI;

public class CheckList : MonoBehaviour
{
    [SerializeField] private string LabelFR;
    [SerializeField] private string LabelEN;
    [SerializeField] public string ItemNameFR;
    [SerializeField] public int NumberOfItemGoal;
    [SerializeField] public int NumberOfItem;
    [SerializeField] public Image Icon;
    [SerializeField] public Sprite DoneIcon;
    [SerializeField] public bool reached;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        NumberOfItem = 0;
    }

    public void CheckIfReached()
    {
        if (NumberOfItem == NumberOfItemGoal)
        {
            reached = true;
            Icon.sprite = DoneIcon;
        }
    }
}
