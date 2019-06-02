using State.Enemy;
using UnityEngine;

namespace Enemies
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private EnemyData _enemyData;

        private EnemyStateMachine _enemyStateMachine;

        public Animator MyAnimator { private set; get; }
        public Health EnemyHealth { private set; get; }
        public float CurrentSpeed { private set; get; }

        private float _frozenSpeed;
        private bool _bIsFrozen;
        private bool _bIsSpawning;
        private float _frozenTimer;

        private SpriteRenderer _renderer;
        private Color _defaultColor;
        private Color _frozenColor;

        private void Start()
        {
            _frozenSpeed = _enemyData.frozenSpeed;

            _renderer = GetComponent<SpriteRenderer>();
            _defaultColor = _renderer.color;
            _frozenColor = Color.blue;

            MyAnimator = gameObject.GetComponent<Animator>();
            _enemyStateMachine = gameObject.AddComponent<EnemyStateMachine>();
            _enemyStateMachine.ChangeState(new EnemyMoveState(), this, _enemyData);

            if (_bIsSpawning == true)
            {
                CurrentSpeed = 0;
            }
        }

        private void Update()
        {
            if (_bIsFrozen)
            {
                _frozenTimer -= Time.deltaTime;
                _renderer.material.color = _frozenColor;

                if (CurrentSpeed != 0)
                {
                    CurrentSpeed = _frozenSpeed;
                }

                if (_frozenTimer <= 0)
                {
                    _bIsFrozen = false;
                    _renderer.material.color = _defaultColor;

                    if (CurrentSpeed != 0)
                    {
                        CurrentSpeed = _enemyData.speed;
                    }
                }
            }

            transform.Translate(Vector2.left * Time.deltaTime * CurrentSpeed);
            _enemyStateMachine.ExecuteState();
        }

        // called from animation events
        public void SetMovementSpeed(float speed)
        {
            Debug.Log("Setting movement speed to " + speed);
            CurrentSpeed = speed;
        }

        // called from animation events
        public void SetIsSpawning(int isSpawning)
        {
            if (isSpawning != 0)
            {
                CurrentSpeed = _enemyData.speed;
            }
            else
            {
                _bIsSpawning = true;
            }
        }
        public void FreezeEnemy(float freezeDuration)
        {
            _frozenTimer += freezeDuration;
            _bIsFrozen = true;
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            var collidedEnemyDefender = collider.GetComponent<Defender>();

            if (collidedEnemyDefender == null)
            {
                return;
            }

            EnemyHealth = collidedEnemyDefender.GetComponent<Health>();

            if (_enemyData.type == EnemyType.Jump && collidedEnemyDefender.IsDefenderJumpable())
            {
                Debug.Log("Performing Jump");
                _enemyStateMachine.ChangeState(new EnemyJumpState(), this, _enemyData);
            }
            else if (_enemyData.type == EnemyType.Ghost)
            {
                Debug.Log("Ghost coming through");
            }
            else
            {
                _enemyStateMachine.ChangeState(new EnemyAttackState(), this, _enemyData);
            }
        }

        private void OnTriggerExit2D(Collider2D collider)
        {
            if (collider.GetComponent<Enemy>() == null)
            {
                return;
            }
            _enemyStateMachine.ChangeState(new EnemyMoveState(), this, _enemyData);
        }
    }
}