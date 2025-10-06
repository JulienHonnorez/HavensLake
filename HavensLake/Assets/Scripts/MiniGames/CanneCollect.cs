using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanneCollect : MonoBehaviour
{
    [SerializeField] private MoveManager MoveManager;
    [SerializeField] private List<GameObject> Points = new List<GameObject>();
    [SerializeField] private List<Item> AllowedItems = new List<Item>();
    [SerializeField] private GameObject Particle;
    [SerializeField] private GameObject Canne;

    private SoundPlayer SoundPlayer;
    private bool Play = false;
    private bool CanCollect = true;
    private int ParticleIndex;
    private int CanneIndex;
    private int TryCount = 0;

    private void OnEnable()
    {
        TryCount = 0;
        Play = true;
        SoundPlayer = GameObject.FindGameObjectWithTag("SoundPlayer").GetComponent<SoundPlayer>();
        StartCoroutine(MoveParticle());
        StartCoroutine(MoveCanne());
    }

    private void OnDisable()
    {
        Play = false;
        StopAllCoroutines();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            TryFish();
    }

    public IEnumerator MoveParticle()
    {
        while (Play)
        {
            var index = Random.Range(0, Points.Count);
            ParticleIndex = index;
            Particle.transform.position = Points[index].transform.position;
            SoundPlayer.PlayBubble();
            yield return new WaitForSeconds(5);
        }
    }

    public IEnumerator MoveCanne()
    {
        for (int index = 0; index < Points.Count; index++)
        {
            CanneIndex = index;
            Canne.transform.position = Points[index].transform.position;
            SoundPlayer.PlayLakeCanne();
            yield return new WaitForSeconds(0.8f);

            CanCollect = true;
        }

        if (Play)
            StartCoroutine(MoveCanne());
    }

    public void TryFish()
    {
        if (!CanCollect) return;

        CanCollect = false;
        SoundPlayer.PlayCanCallBack();
        TryCount++;
        if (CanneIndex == ParticleIndex)
        {
            var index = Random.Range(0, AllowedItems.Count);
            InventoryManager.Instance.TryAddItemToBackpack(AllowedItems[index]);
        }

        if (TryCount >= 5)
            StartCoroutine(Unload());
    }

    public IEnumerator Unload()
    {
        yield return new WaitForSeconds(2);
        MoveManager.Navigate(11);
    }
}