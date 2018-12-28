using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [Range (0f, 3f)] [SerializeField] float maxSpeed = 1f;
    [SerializeField] int damageDealt;
    [SerializeField] float attackCooldown;

    private Animator anim;
    private Defender collidedEnemyTarget;
    private Health enemyHealth;

    private float currentSpeed = 0;
    private float remainingCooldown;

    private bool isCollidingEnemy;

    private void Start()
    {
        anim = GetComponent<Animator>();
        remainingCooldown = attackCooldown;
        isCollidingEnemy = false;
    }

	private void Update ()
    {
        transform.Translate(Vector2.left * Time.deltaTime * currentSpeed);

        // TODO needs refactoring
        if (isCollidingEnemy)
        {
            Attack(collidedEnemyTarget);
        }
    }

    public void SetMovementSpeed()
    {
        currentSpeed = maxSpeed;
    }

    public void ResetMovementSpeed()
    {
        currentSpeed = 0;
    }

    private void Attack(Defender target)
    {
        // in case there are more than one enemy attacking the same target
        if (target == null)
        {
            anim.SetBool("isAttacking", false);
            return;
        }

        enemyHealth = target.GetComponent<Health>();

        if (target.GetComponent<Health>() == null)
        {
            Debug.Log("Target doesn't have health points");
            return;
        }

        anim.SetBool("isAttacking", true);

        if (remainingCooldown <= 0)
        {
            enemyHealth.DealDamage(damageDealt);
            remainingCooldown = attackCooldown;  
        }

        remainingCooldown -= Time.deltaTime;
        
        if (enemyHealth.GetCurrentHealthPoints() <= 0)
        {
            anim.SetBool("isAttacking", false);
            isCollidingEnemy = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        collidedEnemyTarget = collider.GetComponent<Defender>();

        if (collidedEnemyTarget == null) { return; }

        isCollidingEnemy = true;
    }
}
