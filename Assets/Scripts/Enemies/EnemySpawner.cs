using System.Collections;
using UnityEngine;

namespace Enemies
{
    public class EnemySpawner : MonoBehaviour {

        [SerializeField] private float minSpawnDelay = 2f;
        [SerializeField] private float maxSpawnDelay = 5f;

        [SerializeField] private Transform[] spawnPositions;
        [SerializeField] private Enemy[] enemies;

        [SerializeField] private bool bShouldSpawn = true;

        private int _spawnLaneIndex;
        private int _enemyToSpawnIndex;

        // Use this for initialization
        IEnumerator Start ()
        {
            while(bShouldSpawn)
            {
                yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
                _spawnLaneIndex = Random.Range(0, spawnPositions.Length);
                SpawnEnemy(spawnPositions[_spawnLaneIndex]);
            }
        }

        private void SpawnEnemy(Transform spawnPosition)
        {
            _enemyToSpawnIndex = Random.Range(0, enemies.Length);

            Instantiate(enemies[_enemyToSpawnIndex], spawnPosition.position, transform.rotation);
        }

        public void SetShouldSpawn(bool shouldSpawn)
        {
            bShouldSpawn = shouldSpawn;
        }
    }
}
