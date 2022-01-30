using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] WaveConfigSO currentWave;

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    public WaveConfigSO getCurrentWave()
    {
        return currentWave;
    }

    IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < currentWave.GetEnemyCount(); i++)
        {
            GameObject enemy = currentWave.GetEnemyPrefab(i);
            Vector2 startingPosition = currentWave.GetStartingWaypoint().position;
            // Quaternion.identity = no rotation
            Quaternion rotation = Quaternion.identity;
            // Spawn enemy as child of this gameObeject (enemySpawner)
            Transform parent = transform;

            Instantiate(enemy, startingPosition, rotation, parent);

            yield return new WaitForSecondsRealtime(currentWave.GetRandomSpawnTime());
        }
    }
}
