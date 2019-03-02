using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJumpState : IEnemyState
{
    private Enemy _enemy;

    public void Enter(Enemy enemy, EnemyData data)
    {
        _enemy = enemy;

        enemy.SetMovementSpeed(data.Speed * 2);
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