using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Utilities 
{
    public static int playerDeaths = 0;
    

    public static void RestartLevel()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    public static bool RestartLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
        Time.timeScale = 1f;

        return true;
    }
}
