using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekAnimatorController : AnimatorController
{
    // muovi il giocatore con l'animator (on combat), se vedi player, lancia combat

    void Awake()
    {
        InitTransitions();
    }

    void OnEnable()
    {
        animatorService.Combact.WalkForward();
        StartCoroutine(WaitForLost());
    }

    private IEnumerator WaitForLost()
    {
        yield return new WaitForSeconds(7f);
        animatorService.Idle.Lost();
        EnemyStateEvent.alert.Invoke();
    }

    void InitTransitions()
    {
        GameEvent.playerSaw.AddListener(owner => EnemyStateEvent.combact.Invoke(owner.GetInstanceID()));
        //GameEvent.playerLostPosition.AddListener(owner => EnemyStateEvent.alert.Invoke(owner.GetInstanceID()));
    }
}
