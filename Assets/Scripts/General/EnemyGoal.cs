using UnityEngine;

namespace General
{
    public class EnemyGoal : MonoBehaviour
    {
        private Level level;

        void Start()
        {
            level = FindObjectOfType<Level>();
        }
        void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider != null)
            {
                level.GameOver();
            }
        }
    }
}
