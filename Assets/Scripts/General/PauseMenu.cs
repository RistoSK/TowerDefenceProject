using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private GameObject disableScreen;

    public static bool bGameIsPause = false;

    private void Start()
    {
        pauseMenuUI.SetActive(false);
        disableScreen.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (bGameIsPause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        disableScreen.SetActive(true);
        Time.timeScale = 0f;
        bGameIsPause = true;
    }

    public void Resume()
    {
        disableScreen.SetActive(false);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        bGameIsPause = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
