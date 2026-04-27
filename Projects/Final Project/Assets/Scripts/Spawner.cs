using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject fishPrefab;
    public GameObject rainbowFishPrefab;
    public GameObject trashPrefab;
    public GameObject jellyfishPrefab;

    public float spawnRate = 2f;

    public float minY = -4f;
    public float maxY = -2f;

    public float leftX = -9f;
    public float rightX = 9f;

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

        float randomY = Random.Range(minY, maxY);
        bool spawnFromLeft = Random.value > 0.5f;

        Vector2 spawnPosition;
        int direction;

        if (spawnFromLeft)
        {
            spawnPosition = new Vector2(leftX, randomY);
            direction = 1;
        }
        else
        {
            spawnPosition = new Vector2(rightX, randomY);
            direction = -1;
        }

        GameObject spawnedObject = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);

        SidewaysMove moveScript = spawnedObject.GetComponent<SidewaysMove>();
        if (moveScript != null)
        {
            moveScript.SetDirection(direction);
        }
    }
}