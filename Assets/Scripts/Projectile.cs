using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed = 4f;
    [SerializeField] int damageAmount = 10;
    [SerializeField] GameObject deathVFX;
    [SerializeField] float rotationSpeed = 0f;

    Health health;

    private void Update()
    {
        transform.position += (Vector3.right * speed * Time.deltaTime);
        transform.Rotate(0f, 0f, rotationSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<Health>() == null && collider.GetComponent<Enemy>() == null) { return; }

        health = collider.GetComponent<Health>();
        health.DealDamage(damageAmount);

        TriggerDeathVFX();
        Destroy(gameObject);
    }

    private void TriggerDeathVFX()
    {
        if (!deathVFX) { return; }

        GameObject deathVFXObject = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(deathVFXObject, 2f);
    }
}
