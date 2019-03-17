namespace State.Enemy
{
    public class EnemyJumpState : IEnemyState
    {
        private Enemies.Enemy _enemy;

        public void Enter(Enemies.Enemy enemy, EnemyData data)
        {
            _enemy = enemy;

            enemy.SetMovementSpeed(data.speed * 2);
            IsEnemyJumping(true);
        }

        public void Execute()
        {

        }

        public void Exit()
        {
            IsEnemyJumping(false);
        }

        void IsEnemyJumping(bool bShouldJump)
        {
            _enemy.MyAnimator.SetBool("isJumping", bShouldJump);
        }
    }
}