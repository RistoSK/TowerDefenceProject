using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace General
{
    public static class LevelLoader
    {

        public static int level;

        public static void LoadLevel(int i)
        {
            SceneManager.LoadScene(8);
            level = i;
        }
    }
}
