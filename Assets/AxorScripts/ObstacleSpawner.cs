using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public string[] obstacleTypes;

    public float spawnX = 20f;
    public float spawnY = -2f;

    public float minSpawnTime = 1f;
    public float maxSpawnTime = 2f;

    void Start()
    {
        SpawnLoop();
    }

    void SpawnLoop()
    {
        Invoke(nameof(SpawnObstacle), Random.Range(minSpawnTime, maxSpawnTime));
    }

    void SpawnObstacle()
    {
        int random = Random.Range(0, obstacleTypes.Length);

        GameObject obstacle = PoolManager.instance.GetObject(obstacleTypes[random]);

        if (obstacle != null)
        {
            obstacle.transform.position = new Vector3(spawnX, spawnY, 0);
        }

        SpawnLoop();
    }
}
