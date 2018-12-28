using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelLoader : MonoBehaviour {

    private void Start()
    {
        StartCoroutine(LoadingScreenDelay());
    }

    IEnumerator LoadingScreenDelay()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(2);
    }
}
