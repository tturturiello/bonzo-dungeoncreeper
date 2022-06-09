using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertAnimatorController : AnimatorController, IState
{
    // muovi player con Combat animation, se vedi player lancia Combat
    void OnEnable()
    {
        InitTransitions();
        animatorService.Combact.WalkForward();
    }

    public void InitTransitions()
    {
        GameEvent.playerSaw.AddListener(owner => EnemyStateEvent.combact.Invoke(owner.GetInstanceID()));
    }
}
