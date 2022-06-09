using System;
using UnityEngine.SceneManagement;

public static class LevelManager
{
    private const int LEVELS_NUMBER = 2;
    private static int currentLevel = 1;

    internal static void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    internal static void LoadLevel(int level)
    {
        currentLevel = level;
        SceneManager.LoadScene(level);
    }

    internal static void LoadCurrentLevel()
    {
        SceneManager.LoadScene(currentLevel);
    }

    internal static void LoadNextLevel()
    {
        int nextLevel = ++currentLevel;
        if (nextLevel > LEVELS_NUMBER)
        {
            LoadMenu();
            // Application.Quit();
        }
        else
        {
            SceneManager.LoadScene(nextLevel);
        }
    }

    /*
    private static LevelManager _instance;

    private LevelManager() {}

    public static LevelManager Instance()
    {
        if (_instance == null)
        {
            return new LevelManager();
        }
        return _instance;
    }
    */
}
