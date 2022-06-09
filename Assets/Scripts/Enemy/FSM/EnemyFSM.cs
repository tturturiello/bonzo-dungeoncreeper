using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class EnemyFSM : MonoBehaviour
{
    [SerializeField] private GameObject owner;
    // states
    [Header("States")]
    [SerializeField] private GameObject quiet;
    [SerializeField] private GameObject combat;
    [SerializeField] private GameObject alert;
    [SerializeField] private GameObject seek;

    private GameObject currState = null;

    void Awake()
    {
        Init();
        // transitions
        EnemyStateEvent.quiet.AddListener(ID => SetCurrState(ID, quiet));
        EnemyStateEvent.combact.AddListener(ID => SetCurrState(ID, combat));
        EnemyStateEvent.alert.AddListener(() => SetCurrState(alert));
        EnemyStateEvent.seek.AddListener(ID => SetCurrState(ID, seek));
        GameEvent.enemyDead.AddListener(owner => TurnOff(owner.GetInstanceID()));
    }

    void Init()
    {
        SetCurrState(quiet);
        combat.SetActive(false);
        alert.SetActive(false);
        seek.SetActive(false);
    }

    private void SetCurrState(int ID, GameObject state)
    {
        bool isSameGameObject = owner.GetInstanceID().Equals(ID);
        if (isSameGameObject)
            SetCurrState(state);
    }

    private void SetCurrState(GameObject state)
    {
        if (currState != state)
        {
            if (currState != null)
                currState.SetActive(false);

            state.SetActive(true);
            currState = state;
        }
    }

    private void TurnOff(int ID)
    {
        if (IsSameGameObject(ID))
        {
            currState.SetActive(false);
        }
    }

    private bool IsSameGameObject(int ID)
    {
        return ID == owner.GetInstanceID();
    }
}