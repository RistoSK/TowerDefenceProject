namespace State.Enemy
{
    public class EnemyMoveState : IEnemyState
    {
        private global::Enemies.Enemy _enemy;
        private EnemyData _enemyData;

        public void Enter(global::Enemies.Enemy enemy, EnemyData data)
        {
            _enemy = enemy;
            _enemyData = data;
            enemy.SetMovementSpeed(data.speed);
        }

        public void Execute()
        {

        }

        public void Exit()
        {

        }
    }
}
