using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public string[] easyObstacles;
    public string[] mediumObstacles;
    public string[] hardObstacles;

    public float spawnX = 20f;
    public float spawnY = -2f;

    public float minSpawnDistance = 6f;
    public float maxSpawnDistance = 12f;

    public string wallObstacle = "obstaculo2";

    public float wallExtraSpace = 10f;
    public float wallSpawnChance = 0.15f;
    public float wallStartDistance = 150f;

    private float nextSpawnDistance;

    public string pauseZoneObject = "pauseZone";

    public float pauseZoneDistance = 300f;
    public float pauseZoneSafeDistance = 25f;

    float nextPauseZone;

    void Start()
    {
        SetNextSpawn();
        nextPauseZone = pauseZoneDistance;
    }

    void Update()
    {
        float distance = GameManager.instance.distanceTravelled;

        if (distance >= nextPauseZone)
        {
            SpawnPauseZone();
            nextPauseZone += pauseZoneDistance;
        }

        if (distance >= nextSpawnDistance)
        {
            SpawnObstacle();
            SetNextSpawn();
        }
    }

    void SetNextSpawn()
    {
        float speed = GameManager.instance.speed;

        float minTime = 1.2f;
        float maxTime = 2f;

        float time = Random.Range(minTime, maxTime);

        float spawnDistance = speed * time;

        // límites importantes
        float minDistance = 6f;
        float maxDistance = 30f;

        spawnDistance = Mathf.Clamp(spawnDistance, minDistance, maxDistance);

        nextSpawnDistance =
            GameManager.instance.distanceTravelled + spawnDistance;
    }

    void SpawnObstacle()
    {
        string obstacleType = GetObstacle();

        if (GameManager.instance.distanceTravelled > wallStartDistance &&
        Random.value < wallSpawnChance)
        {
            obstacleType = wallObstacle;
        }

        GameObject obstacle = PoolManager.instance.GetObject(obstacleType);

        if (obstacle != null)
        {
            obstacle.transform.position =
                new Vector3(spawnX, spawnY, 0);
        }

        if (obstacleType == wallObstacle)
        {
            float extraTime = 2f;

            float extraDistance =
                GameManager.instance.speed * extraTime;

            extraDistance = Mathf.Max(extraDistance, wallExtraSpace);

            nextSpawnDistance += extraDistance;
        }
    }

    string GetObstacle()
    {
        float distance = GameManager.instance.distanceTravelled;

        float difficulty = Mathf.Clamp01(distance / 1000f);

        float easyChance = Mathf.Lerp(0.7f, 0.35f, difficulty);
        float mediumChance = Mathf.Lerp(0.2f, 0.4f, difficulty);

        float roll = Random.value;

        if (roll < easyChance)
            return easyObstacles[Random.Range(0, easyObstacles.Length)];

        if (roll < easyChance + mediumChance)
            return mediumObstacles[Random.Range(0, mediumObstacles.Length)];

        return hardObstacles[Random.Range(0, hardObstacles.Length)];
    }

    void SpawnPauseZone()
    {
        GameObject zone = PoolManager.instance.GetObject(pauseZoneObject);

        if (zone != null)
        {
            zone.transform.position =
                new Vector3(spawnX, spawnY, 0);
        }

        // empujar el siguiente spawn de obstáculo
        nextSpawnDistance =
            GameManager.instance.distanceTravelled + pauseZoneSafeDistance;
    }
}
