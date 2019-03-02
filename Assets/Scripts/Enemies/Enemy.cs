using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyData _enemyData;

    private EnemyStateMachine _enemyStateMachine;
    private float _currentSpeed;

    void Start()
    {
        _currentSpeed = _enemyData.Speed;
        MyAnimator = gameObject.GetComponent<Animator>();
        _enemyStateMachine = gameObject.AddComponent<EnemyStateMachine>();
        _enemyStateMachine.ChangeState(new EnemyMoveState(), this, _enemyData);
    }

    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * _currentSpeed);
        _enemyStateMachine.ExecuteState();
    }

    public Animator MyAnimator { private set; get; }
    public Defender CollidedEnemyDefender { private set; get; }

    // called from animation events
    public void SetMovementSpeed(float speed)
    {
        Debug.Log("Setting movement speed to " + speed);
        _currentSpeed = speed;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<Defender>() == null) { return; }
        Debug.Log("Entering Collider");

        CollidedEnemyDefender = collider.GetComponent<Defender>();
        var enemyHealth = CollidedEnemyDefender.GetComponent<Health>();

        Debug.Log("_enemyData.ShouldJump " + _enemyData.ShouldJump + " CollidedEnemyDefender.isDefenderJumpable() " + CollidedEnemyDefender.isDefenderJumpable());
        if (_enemyData.ShouldJump && CollidedEnemyDefender.isDefenderJumpable())
        {
            Debug.Log("Performing Jump");
            _enemyStateMachine.ChangeState(new EnemyJumpState(), this, _enemyData);
        }
        else
        {
            _enemyStateMachine.ChangeState(new EnemyAttackState(), this, _enemyData);
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        Debug.Log("Exiting Collider");
        _enemyStateMachine.ChangeState(new EnemyMoveState(), this, _enemyData);
    }
}