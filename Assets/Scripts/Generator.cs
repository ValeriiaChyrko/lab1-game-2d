using ObjectPooling;
using UnityEngine;

[RequireComponent(typeof(ObjectPool))]
public class Generator : MonoBehaviour
{
    [SerializeField] private GameObject[] objectPrefabs;
    [SerializeField] private ObjectPool objectPool;
    [SerializeField] private float spawnRate = 2.0f;
    [SerializeField] private float topRowY = 15.0f;
    [SerializeField] private float spawnMinX = -5.0f;
    [SerializeField] private float spawnMaxX = 5.0f;

    private float _nextSpawnTime;

    private void Update()
    {
        if (Time.time <= _nextSpawnTime) return;
        SpawnObject();
        _nextSpawnTime = Time.time + spawnRate;
    }

    private void SpawnObject()
    {
        if (objectPrefabs.Length <= 0) return;

        var randomIndex = Random.Range(0, objectPrefabs.Length);
        var randomPrefab = objectPrefabs[randomIndex];
        var randomX = Random.Range(spawnMinX, spawnMaxX);
        var spawnPosition = new Vector3(randomX, topRowY);

        var spawnedObject = objectPool.GetObject(randomPrefab);
        spawnedObject.transform.position = spawnPosition;
        spawnedObject.SetActive(true);
    }
}