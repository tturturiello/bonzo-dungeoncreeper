using System;
using System.Collections;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private float slowDownFactor = 0.05f;
    [SerializeField] private float slowDownLenght = 2f;


    private void Awake()
    {
        GameEvent.playerDead.AddListener(() =>
            StartCoroutine(TempSlowMotion(0.3f, 4f)));
    }

    private void SlowMotion()
    {
        Time.timeScale = slowDownFactor;
        Time.fixedDeltaTime = Time.timeScale * .02f;
    }


    private IEnumerator TempSlowMotion(float delay, float secs)
    {
        yield return WaitAndApply(delay, SlowMotion);
        yield return WaitAndApply(secs, ResetTime);
    }

    private void ResetTime()
    {
        Time.timeScale = 1f;
        Time.fixedDeltaTime = Time.fixedUnscaledDeltaTime;
    }

    private IEnumerator WaitAndApply(float secs, Action action)
    {
        yield return new WaitForSeconds(secs * Time.timeScale);
        action.Invoke();
    }
}
