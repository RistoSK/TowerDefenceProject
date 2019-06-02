using System.Collections;
using Enemies;
using UnityEngine;

namespace Projectile
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private ProjectileData projectileData;

        private Health _health;
        private Enemy _enemy;
    
        private void Start()
        {
            if (projectileData == null)
            {
                Debug.Log("Projectile data is missing");
            }
        }

        private void FixedUpdate()
        {
            transform.position += (Vector3.right * projectileData.speed * Time.deltaTime);
            transform.Rotate(0f, 0f, projectileData.rotationSpeed);
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.GetComponent<Health>() == null && collider.GetComponent<Enemy>() == null) { return; }

            _health = collider.GetComponent<Health>();
            _health.DealDamage(projectileData.damageAmount, projectileData.hitGhosts);

            if (projectileData.freezeEnemies)
            {
                _enemy = collider.GetComponent<Enemy>();
                _enemy.FreezeEnemy(projectileData.freezeDuration);

            }

            TriggerDeathVFX();
            Destroy(gameObject);
        }

        private void TriggerDeathVFX()
        {
            if (!projectileData.deathVFX) { return; }

            GameObject deathVFXObject = Instantiate(projectileData.deathVFX, transform.position, transform.rotation);
            Destroy(deathVFXObject, 2f);
        }
    }
}
