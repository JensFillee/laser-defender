using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> waveConfigs;
    [SerializeField] float timeBetweenWaves = 0f;
    WaveConfigSO currentWave;

    void Start()
    {
        StartCoroutine(SpawnEnemyWaves());
    }

    public WaveConfigSO getCurrentWave()
    {
        return currentWave;
    }


    IEnumerator SpawnEnemyWaves()
    {
        foreach (WaveConfigSO wave in waveConfigs)
        {
            currentWave = wave;

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

            yield return new WaitForSecondsRealtime(timeBetweenWaves);
        }
    }
}
