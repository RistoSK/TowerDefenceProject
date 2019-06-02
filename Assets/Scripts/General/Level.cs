using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace General
{
    public class Level : MonoBehaviour
    {
        private GameSession _gameSession;

        [SerializeField] private GameObject levelCompletedCanvas;
        [SerializeField] private AudioClip youWonAudio;

        private void Awake()
        {
            _gameSession = FindObjectOfType<GameSession>();
        
            levelCompletedCanvas.SetActive(false);
        }

        public void StartMenu()
        {
            SceneManager.LoadScene(0);
        }

        public void PlayTutorial()
        {
            SceneManager.LoadScene(1);

            if (_gameSession)
            {
                _gameSession.ResetGame();
            }
        }

        public void WonGame()
        {
            levelCompletedCanvas.SetActive(true);

            if (Camera.main != null)
            {
                AudioSource.PlayClipAtPoint(youWonAudio, Camera.main.transform.position);
            }
        }

        public void QuitGame()
        {
            Application.Quit();
        }

        public void GameOver()
        {
            StartCoroutine(GameOverDelay());
        }

        IEnumerator GameOverDelay()
        {
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene(3);
        }

        public void PlayCampaing()
        {
            SceneManager.LoadScene(3);

            if (_gameSession)
            {
                _gameSession.ResetGame();
            }
        }

        public void PlayImpossibleMode()
        {
            SceneManager.LoadScene(4);

            if (_gameSession)
            {
                _gameSession.ResetGame();
            }
        }

    }
}
