using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private ProjectileData _projectileData;

    private Health _health;
    
    void Start()
    {
        if (_projectileData == null)
        {
            Debug.Log("Projectile data is missing");
        }
    }

    void Update()
    {
        transform.position += (Vector3.right * _projectileData.Speed * Time.deltaTime);
        transform.Rotate(0f, 0f, _projectileData.RotationSpeed);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<Health>() == null && collider.GetComponent<Enemy>() == null) { return; }

        _health = collider.GetComponent<Health>();
        _health.DealDamage(_projectileData.DamageAmount);

        TriggerDeathVFX();
        Destroy(gameObject);
    }

    void TriggerDeathVFX()
    {
        if (!_projectileData.DeathVFX) { return; }

        GameObject deathVFXObject = Instantiate(_projectileData.DeathVFX, transform.position, transform.rotation);
        Destroy(deathVFXObject, 2f);
    }
}
