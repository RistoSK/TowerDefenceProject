using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveState : IEnemyState
{
    private Enemy _enemy;
    private EnemyData _enemyData;

    public void Enter(Enemy enemy, EnemyData data)
    {
        _enemy = enemy;
        _enemyData = data;
        enemy.SetMovementSpeed(data.Speed);
    }

    public void Execute()
    {

    }

    public void Exit()
    {

    }
}
