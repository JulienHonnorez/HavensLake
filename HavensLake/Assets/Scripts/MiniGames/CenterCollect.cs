using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CenterCollect : MonoBehaviour
{
    [SerializeField] private MoveManager MoveManager;
    [SerializeField] private Animator TreuilAnimator;
    [SerializeField] private Animator CanneAnimator;
    [SerializeField] private Image ItemFoundImage;
    [SerializeField] private List<Item> AllowedItems = new List<Item>();

    private SoundPlayer SoundPlayer;
    private bool CanInterract = false;
    private int CurrentScore = 0;

    private void OnEnable()
    {
        SoundPlayer = GameObject.FindGameObjectWithTag("SoundPlayer").GetComponent<SoundPlayer>();
        CurrentScore = 0;
        TreuilAnimator.speed = 1f;
        SoundPlayer.PlayTreuil();
        ItemFoundImage.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (CanInterract)
                CurrentScore++;
            else
                CurrentScore--;

            CheckIfGameStatus();
        }
    }

    private void CheckIfGameStatus()
    {
        if (CurrentScore < 0)
        {
            TreuilAnimator.speed = 0f;
            SoundPlayer.StopTreuil();
            CanInterract = false;
            StartCoroutine(Unload());
        }
        else if (CurrentScore >= 3)
        {
            CanInterract = false;
            CanneAnimator.SetTrigger("3");
            SoundPlayer.PlayChain();
            StartCoroutine(GotIt());
        }
        else
        {
            CanneAnimator.SetTrigger(CurrentScore.ToString());
            SoundPlayer.PlayChain();
            TreuilAnimator.speed = Random.Range(1f, 2f);
        }
    }

    public void SetInterractStatusOK()
    {
        CanInterract = true;
    }

    public void SetInterractStatusNOK()
    {
        CanInterract = false;
    }

    public IEnumerator ResetCanne()
    {
        yield return new WaitForSeconds(2);
        ItemFoundImage.gameObject.SetActive(false);
    }

    public IEnumerator GotIt()
    {
        var itemFound = AllowedItems[Random.Range(0, AllowedItems.Count)];
        TreuilAnimator.speed = 0f;
        SoundPlayer.StopTreuil();

        yield return new WaitForSeconds(1f);

        ItemFoundImage.gameObject.SetActive(true);
        ItemFoundImage.sprite = itemFound.BaseSprite;
        CanneAnimator.SetTrigger("GotIt");
        SoundPlayer.PlayChainGotIt();

        yield return new WaitForSeconds(3f);

        InventoryManager.Instance.TryAddItemToBackpack(itemFound);
        StartCoroutine(Unload());
    }

    public IEnumerator Unload()
    {
        yield return new WaitForSeconds(2);
        MoveManager.Navigate(12);
    }
}
