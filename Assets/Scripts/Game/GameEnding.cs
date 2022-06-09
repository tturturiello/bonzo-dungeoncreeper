using System;
using System.Collections;
using UnityEngine;

public class GameEnding : MonoBehaviour
{
    [SerializeField] private float fadeDuration = 1f;
    [SerializeField] private float displayImageDuration = 1f;
    [SerializeField] private GameObject player;
    [SerializeField] private CanvasGroup exitBackgroundImageCanvasGroup;
    [SerializeField] private CanvasGroup deadBackgroundImageCanvasGroup;

    private float timer;

    private void Awake()
    {
        GameEvent.exitReached.AddListener(OnGameWon);
        GameEvent.playerDead.AddListener(OnGameOver);
        StartCoroutine(ExitGame());
    }

    IEnumerator ExitGame()
    {
        yield return new WaitUntil(() => Input.GetKey(KeyCode.Escape));
        Application.Quit();
    }

    void OnGameWon(GameObject toAssertPlayer)
    {
        if (toAssertPlayer.CompareTag("Player")
            || toAssertPlayer.layer == 13)
        {
            GameEvent.won.Invoke();
            IEnumerator winFade = WaitForFaderEndLevel(
                    exitBackgroundImageCanvasGroup, true);
            StartCoroutine(winFade);
        }
    }

    void OnGameOver()
    {
        IEnumerator gameOverFade = WaitForFaderEndLevel(deadBackgroundImageCanvasGroup, false);
        StartCoroutine(gameOverFade);
    }

    IEnumerator WaitForFaderEndLevel(CanvasGroup canvasGroup, bool hasWon)
    {
        yield return new WaitForEndOfFrame();
        timer += Time.deltaTime;
        canvasGroup.alpha = timer / fadeDuration;

        if (timer > fadeDuration + displayImageDuration)
            EndLevel(hasWon);
        else
            StartCoroutine(WaitForFaderEndLevel(canvasGroup, hasWon));
    }

    public void EndLevel(bool hasWon)
    {
        if (hasWon)
        {
            StartCoroutine(WaitForEndOfSounds());
        }
        else
        {
            LevelManager.LoadCurrentLevel();
            //SceneManager.LoadScene(currentLevel);
        }
    }

    private IEnumerator WaitForEndOfSounds()
    {
        yield return new WaitForSeconds(2f);
        LevelManager.LoadNextLevel();

        /*
        //int nextLevel = ++currentLevel;
        Debug.Log("curr level " + currentLevel);
        if (nextLevel > LEVELS_NUMBER)
        {
            Debug.Log("quit");
            Application.Quit();
            // TODO: carica menu
        }
        else
        {
            //SceneManager.LoadScene(nextLevel);
            LevelManager.LoadNextLevel();
        }
        */
    }
}