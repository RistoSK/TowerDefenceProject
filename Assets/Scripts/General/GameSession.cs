using UnityEngine;

namespace General
{
    public class GameSession : MonoBehaviour
    {
        void Awake()
        {
            SetupSingleton();
        }

        private void SetupSingleton()
        {
            if (FindObjectsOfType<GameSession>().Length > 1)
            {
                Destroy(gameObject);
            }
            else
            {
                DontDestroyOnLoad(gameObject);
            }
        }

        public void ResetGame()
        {
            Destroy(gameObject);
        }
    }
}
