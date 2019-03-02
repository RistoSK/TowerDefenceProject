using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Level : MonoBehaviour
{
    private GameSession gameSession;

    [SerializeField] private GameObject _levelCompletedCanvas;

    [SerializeField] private AudioClip _youWonAudio;

    private void Awake()
    {
        gameSession = FindObjectOfType<GameSession>();
        
        _levelCompletedCanvas.SetActive(false);
    }

    public void StartMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);

        if (gameSession)
        {
            gameSession.ResetGame();
        }
    }

    public void WonGame()
    {
        _levelCompletedCanvas.SetActive(true);

        AudioSource.PlayClipAtPoint(_youWonAudio, Camera.main.transform.position);
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
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(3);
    }
}
