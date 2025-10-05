using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCollect : MonoBehaviour
{
    [SerializeField] private MoveManager MoveManager;
    [SerializeField] private List<GameObject> AllowedItems = new List<GameObject>();

    [SerializeField] private Collider2D SpawnZone;
    [SerializeField] private GameObject PopingItemPrefab;
    [SerializeField] private Transform Container;
    [SerializeField] private float minInterval = 3f;
    [SerializeField] private float maxInterval = 6f;
    [SerializeField] private int maxAttemptsPerSpawn = 50;
    [SerializeField] private int NumberOfItemPerSession = 5;

    private Coroutine spawnRoutine;
    private int ItemCount = 0;

    void OnEnable()
    {
        if (Container == null) Container = this.transform;

        StopSpawning();

        for (int i = Container.transform.childCount - 1; i >= 0; i--)
        {
            GameObject child = Container.transform.GetChild(i).gameObject;
            Destroy(child);
        }

        ItemCount = 0;
        StartSpawning();
    }

    public void StartSpawning()
    {
        if (spawnRoutine == null)
            spawnRoutine = StartCoroutine(SpawnRoutine());
    }

    public void StopSpawning()
    {
        if (spawnRoutine != null)
        {
            StopCoroutine(spawnRoutine);
            spawnRoutine = null;
        }
    }

    private IEnumerator SpawnRoutine()
    {
        while (ItemCount < NumberOfItemPerSession)
        {
            TrySpawnOnce();
            ItemCount++;
            yield return new WaitForSeconds(Random.Range(minInterval, maxInterval));
        }

        StopSpawning();
        MoveManager.Navigate(9);
    }

    private void TrySpawnOnce()
    {
        if (SpawnZone == null)
        {
            Debug.LogWarning("TimedColliderSpawner: Aucun collider assigné !");
            return;
        }

        Bounds b = SpawnZone.bounds;

        for (int attempt = 0; attempt < maxAttemptsPerSpawn; attempt++)
        {
            // Choisit une position aléatoire dans les bounds du collider
            Vector2 worldPos = new Vector2(
                Random.Range(b.min.x, b.max.x),
                Random.Range(b.min.y, b.max.y)
            );

            // Vérifie si le point est bien DANS le collider
            if (SpawnZone.OverlapPoint(worldPos))
            {
                var randomScale = Random.Range(0.5f, 1f);
                var randomItem = AllowedItems[Random.Range(0, AllowedItems.Count)];

                var star = Instantiate(PopingItemPrefab, worldPos, Quaternion.identity, Container);
                star.transform.localScale = new Vector3(randomScale, randomScale, 1);
                star.GetComponent<HandCollectItem>().Item = randomItem.GetComponent<Item>();
                return;
            }
        }

        Debug.LogWarning("TimedColliderSpawner: Aucune position valide trouvée après plusieurs tentatives.");
    }

    // Pour voir la zone dans l’éditeur
    void OnDrawGizmosSelected()
    {
        if (SpawnZone != null)
        {
            Gizmos.color = Color.cyan;
            Bounds b = SpawnZone.bounds;
            Gizmos.DrawWireCube(b.center, b.size);
        }
    }
}