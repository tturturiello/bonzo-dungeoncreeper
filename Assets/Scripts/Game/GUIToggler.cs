using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIToggler : MonoBehaviour
{
    [SerializeField] private GameObject[] toggleOnDeath = null;

    void Awake()
    {
        GameEvent.playerDead.AddListener(OnPlayerDeath);
    }

    private void OnPlayerDeath()
    {
        if (toggleOnDeath != null)
            foreach (var item in toggleOnDeath)
                item.SetActive(false);
    }
}
