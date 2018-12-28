using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] Transform spawnPosition;
    [SerializeField] float defenderShootingCooldown = 4;

    private float remainingCooldown;
    private RaycastHit2D hit;
    private Animator anim;

    private void Start ()
    {
        remainingCooldown = defenderShootingCooldown;
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate ()
    {
        hit = Physics2D.Raycast(transform.position, Vector2.right, 10f, LayerMask.GetMask("Enemy"));
        
        if (hit.collider != null)
        {
            if (anim == null)
            {
                Debug.Log("Animator is missing");
                return;
            }
            anim.Play("Attack");
            Shoot();
        }
    }

    private void Shoot()
    {   
        if (remainingCooldown <= 0)
        {
            Instantiate(projectile, spawnPosition.position, transform.rotation);
            remainingCooldown = defenderShootingCooldown;
        }
        remainingCooldown -= Time.deltaTime;
    }
}