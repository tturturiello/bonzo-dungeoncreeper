using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// muovi player usando Motion, se vedi player, lancia stato "Combat"
public class QuietAnimatorController : AnimatorController
{
    [SerializeField] bool hasMotionOnStart = false;

    void Awake()
    {
        InitTransitions();
    }

    void OnEnable()
    {
        if (hasMotionOnStart)
            Move();
        else
            Stop();
    }

    void InitTransitions()
    {
        GameEvent.playerSaw.AddListener(owner => EnemyStateEvent.combact.Invoke(owner.GetInstanceID()));
    }

    void Move()
    {
        animatorService.Motion.Walk();
    }

    void Stop()
    {
        animatorService.Idle.Wait();
    }
}
