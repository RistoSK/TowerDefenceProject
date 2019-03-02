﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    private IEnemyState _currentEnemyState;

    public void ChangeState(IEnemyState newState, Enemy enemy, EnemyData data)
    {
        if (_currentEnemyState != null)
        {
            _currentEnemyState.Exit();
        }
        _currentEnemyState = newState;
        _currentEnemyState.Enter(enemy, data);
        
    }

    public void ExecuteState()
    {
        if (_currentEnemyState == null)
        {
            Debug.LogError("Current enemy state is null");
            return;
        }
        _currentEnemyState.Execute();
    }
}