using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace General
{
    public class Level : MonoBehaviour
    {
        private GameSession _gameSession;

        [SerializeField] private GameObject _levelCompletedCanvas;
        [SerializeField] private GameObject _loadingCanvas;
        [SerializeField] private GameObject _gameOverCanvas;
        [SerializeField] private AudioClip _youWonAudio;
        [SerializeField] private int _currentLevel;
        [SerializeField] private CharacterBoard _characterBoard;

        private void Awake()
        {
            _gameSession = FindObjectOfType<GameSession>();

            if (_levelCompletedCanvas != null)
            {
                _levelCompletedCanvas.SetActive(false);
            }
        }

        public void PlayTutorial()
        {
            StartCoroutine(LoadLevelWithDelay(0));

            if (_gameSession)
            {
                _gameSession.ResetGame();
            }
        }

        public void WonGame()
        {
            _levelCompletedCanvas.SetActive(true);

            if (Camera.main != null)
            {
                AudioSource.PlayClipAtPoint(_youWonAudio, Camera.main.transform.position);
            }

            StartCoroutine(CharacterBoardDelay());
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
            AudioListener.pause = true;
            _gameOverCanvas.SetActive(true);
        }

        IEnumerator CharacterBoardDelay()
        {
            yield return new WaitForSeconds(5);
            _characterBoard.OpenCharacterBoard();
        }

        public void Retry()
        {
            AudioListener.pause = false;
            _gameOverCanvas.SetActive(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void PlayCampaign()
        {
            SceneManager.LoadScene(0);

            if (_gameSession)
            {
                _gameSession.ResetGame();
            }
        }

        public void PlayLastStage()
        {
            SceneManager.LoadScene(6);

            if (_gameSession)
            {
                _gameSession.ResetGame();
            }
        }

        public void PlayNextLevelCampaignMode()
        {
            _currentLevel++;
            StartCoroutine(LoadLevelWithDelay(_currentLevel));

            if (_gameSession)
            {
                _gameSession.ResetGame();
            }
        }

        private IEnumerator LoadLevelWithDelay(int i)
        {
            _loadingCanvas.SetActive(true);
            yield return new WaitForSeconds(3);
            SceneManager.LoadScene(i);
        }
    }
}
