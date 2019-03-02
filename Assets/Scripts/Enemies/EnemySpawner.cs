using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [SerializeField] private float _minSpawnDelay = 2f;
    [SerializeField] private float _maxSpawnDelay = 5f;

    [SerializeField] private Transform[] _spawnPositions;
    [SerializeField] private Enemy[] _enemies;

    [SerializeField] private bool _bShouldSpawn = true;

    private int _spawnLaneIndex;
    private int _enemyToSpawnIndex;

	// Use this for initialization
	IEnumerator Start ()
    {
        while(_bShouldSpawn)
        {
            yield return new WaitForSeconds(Random.Range(_minSpawnDelay, _maxSpawnDelay));
            _spawnLaneIndex = Random.Range(0, _spawnPositions.Length);
            SpawnEnemy(_spawnPositions[_spawnLaneIndex]);
        }
	}

    private void SpawnEnemy(Transform spawnPosition)
    {
        _enemyToSpawnIndex = Random.Range(0, _enemies.Length);

        Instantiate(_enemies[_enemyToSpawnIndex], spawnPosition.position, transform.rotation);
    }

    public void SetShouldSpawn(bool shouldSpawn)
    {
        _bShouldSpawn = shouldSpawn;
    }
}
