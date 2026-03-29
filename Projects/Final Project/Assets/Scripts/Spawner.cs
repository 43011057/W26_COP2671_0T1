using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject fishPrefab;
    public GameObject rainbowFishPrefab;
    public GameObject trashPrefab;
    public GameObject jellyfishPrefab;

    public float spawnRate = 2f;
    public float minX = -7f;
    public float maxX = 7f;
    public float spawnY = 4f;

    void Start()
    {
        InvokeRepeating("SpawnObject", 1f, spawnRate);
    }

    void SpawnObject()
    {
        if (GameManager.instance.gameEnded)
            return;

        int randomChoice = Random.Range(0, 4);

        GameObject objectToSpawn = fishPrefab;

        if (randomChoice == 0)
        {
            objectToSpawn = fishPrefab;
        }
        else if (randomChoice == 1)
        {
            objectToSpawn = rainbowFishPrefab;
        }
        else if (randomChoice == 2)
        {
            objectToSpawn = trashPrefab;
        }
        else if (randomChoice == 3)
        {
            objectToSpawn = jellyfishPrefab;
        }

        float randomX = Random.Range(minX, maxX);
        Vector2 spawnPosition = new Vector2(randomX, spawnY);

        Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
    }
}