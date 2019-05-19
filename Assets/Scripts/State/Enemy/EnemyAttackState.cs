using UnityEngine;

namespace State.Enemy
{
    public class EnemyAttackState : IEnemyState
    {
        private Enemies.Enemy _enemy;
        private Health _enemyHealth;
        private Animator _anim;
        private EnemyData _enemyData;
        private float _remainingCooldown;

        public void Enter(Enemies.Enemy enemy, EnemyData data)
        {
            _enemy = enemy;
            _enemyHealth = _enemy.EnemyHealth;
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
                _enemyHealth.DealDamage(_enemyData.damage, false);
                _remainingCooldown = _enemyData.attackCooldown;
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
}
