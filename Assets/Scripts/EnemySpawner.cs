using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [SerializeField] float minSpawnDelay = 2f;
    [SerializeField] float maxSpawnDelay = 5f;

    [SerializeField] Transform[] spawnPositions;
    [SerializeField] Enemy enemy;

    bool bSpawn = true;
    int spawnLaneIndex = 0;

	// Use this for initialization
	IEnumerator Start ()
    {
        while(bSpawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            spawnLaneIndex = Random.Range(0, spawnPositions.Length);
            SpawnEnemy(spawnPositions[spawnLaneIndex]);
        }
	}

    private void SpawnEnemy(Transform spawnPosition)
    {
        Instantiate(enemy, spawnPosition.position, transform.rotation);
    }
}
