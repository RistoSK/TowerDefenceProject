using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace General
{
    public class LevelLoader : MonoBehaviour {

        void Start()
        {
            StartCoroutine(LoadingScreenDelay());
        }

        IEnumerator LoadingScreenDelay()
        {
            yield return new WaitForSeconds(3);
            SceneManager.LoadScene(2);
        }
    }
}
