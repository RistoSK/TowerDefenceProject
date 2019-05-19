using State.Enemy;
using UnityEngine;

namespace Enemies
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private EnemyData enemyData;

        private EnemyStateMachine _enemyStateMachine;

        public Animator MyAnimator { private set; get; }
        public Health EnemyHealth { private set; get; }
        public float CurrentSpeed { private set; get; }

        private void Start()
        {
            CurrentSpeed = enemyData.speed;
            MyAnimator = gameObject.GetComponent<Animator>();
            _enemyStateMachine = gameObject.AddComponent<EnemyStateMachine>();
            _enemyStateMachine.ChangeState(new EnemyMoveState(), this, enemyData);
        }

        void Update()
        {
            transform.Translate(Vector2.left * Time.deltaTime * CurrentSpeed);
            _enemyStateMachine.ExecuteState();
        }

        // called from animation events
        public void SetMovementSpeed(float speed)
        {
            Debug.Log("Setting movement speed to " + speed);
            CurrentSpeed = speed;
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            var collidedEnemyDefender = collider.GetComponent<Defender>();
    
            EnemyHealth = collidedEnemyDefender.GetComponent<Health>();

            if (enemyData.type == EnemyType.Jump && collidedEnemyDefender.IsDefenderJumpable())
            {
                Debug.Log("Performing Jump");
                _enemyStateMachine.ChangeState(new EnemyJumpState(), this, enemyData);
            }
            else if (enemyData.type == EnemyType.Ghost)
            {
                Debug.Log("Ghost coming through");
            }
            else
            {
                _enemyStateMachine.ChangeState(new EnemyAttackState(), this, enemyData);
            }
        }

        private void OnTriggerExit2D(Collider2D collider)
        {
            if (collider.GetComponent<Enemy>() == null)
            {
                return;
            }
            _enemyStateMachine.ChangeState(new EnemyMoveState(), this, enemyData);
        }
    }
}