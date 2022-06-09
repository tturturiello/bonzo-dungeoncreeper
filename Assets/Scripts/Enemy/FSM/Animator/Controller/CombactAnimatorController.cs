using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombactAnimatorController : AnimatorController
{
    // Se si allontana => Corri
    // altrimenti => Muovi e attacca
    // se non lo vedi piu', lancia stato SEEK
    void Awake()
    {
        InitTransitions();
    }

    void OnEnable()
    {
        animatorService.Idle.Indicate();
        animatorService.Combact.Run();
    }

    void InitTransitions()
    {
        GameEvent.playerFarAway.AddListener(owner => Run(owner.GetInstanceID()));
        GameEvent.playerCloseTo.AddListener(owner => Combat(owner.GetInstanceID()));
        GameEvent.playerLostSight.AddListener(owner => EnemyStateEvent.seek.Invoke(owner.GetInstanceID()));
        GameEvent.playerDead.AddListener(Victory);
    }

    void Run(int ID)
    {
        if (IsSameGameObject(ID))
            animatorService.Combact.Run();
    }

    void Combat(int ID)
    {
        Attack(ID);
        // ...
    }

    void Attack(int ID)
    {
        if (IsSameGameObject(ID))
            animatorService.Combact.Attack();
    }

    void Victory()
    {
        animatorService.Idle.Victory();
    }
}
