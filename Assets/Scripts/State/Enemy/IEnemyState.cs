using Enemies;

public interface IEnemyState
{
    void Enter(Enemy enemy, EnemyData data);
    void Execute();
    void Exit();
}
