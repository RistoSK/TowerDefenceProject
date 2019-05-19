using System.Collections;
using Enemies;
using UnityEngine;

namespace Projectile
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private ProjectileData projectileData;
        [SerializeField] private bool bHitGhost;
        [SerializeField] private bool bShouldFreeze;

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
            _health.DealDamage(projectileData.damageAmount, bHitGhost);

            if (bShouldFreeze)
            {
                _enemy = collider.GetComponent<Enemy>();

                StartCoroutine(FreezeEnemy(_enemy));
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

        private IEnumerator FreezeEnemy(Enemy enemy)
        {
            enemy.SetMovementSpeed(enemy.CurrentSpeed / 2);
            // TODO turn frozen
            yield return new WaitForSeconds(3);
            enemy.SetMovementSpeed(enemy.CurrentSpeed);
            // TODO unfreeze
        }
    }
}
