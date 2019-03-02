using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : IEnemyState
{
    private Enemy _enemy;
    private Health _enemyHealth;
    private Animator _anim;
    private EnemyData _enemyData;
    private float _remainingCooldown;

    public void Enter(Enemy enemy, EnemyData data)
    {
        _enemy = enemy;
        _anim = enemy.MyAnimator;
        _remainingCooldown = 0;
        _enemyData = data;

        enemy.SetMovementSpeed(0);
    }

    public void Execute()
    {
        IsEnemyAttacking(true);

        if (_remainingCooldown <= 0)
        {
            _enemyHealth.DealDamage(_enemyData.Damage);
            _remainingCooldown = _enemyData.AttackCooldown;
        }

        _remainingCooldown -= Time.deltaTime;
    }

    public void Exit()
    {
        IsEnemyAttacking(false);
    }

    private void IsEnemyAttacking(bool shouldAttack)
    {
        _anim.SetBool("isAttacking", shouldAttack);
    }
}
