using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ToggleOnDeath : MonoBehaviour
{
    [SerializeField] private Behaviour[] behaviours;
    [SerializeField] private GameObject[] gameObjects;
    [SerializeField] private Collider[] colliders;
    [SerializeField] private AudioSource[] audioSources;

    void Awake()
    {
        GameEvent.enemyDead.AddListener(owner => OnDeath(owner.GetInstanceID()));
    }

    void OnDeath(int ID)
    {
        if (gameObject.GetInstanceID().Equals(ID))
        {
            foreach (Behaviour b in behaviours)
            {
                b.enabled = false;
            }
            foreach (GameObject go in gameObjects)
            {
                go.SetActive(false);
            }
            foreach (Collider c in colliders)
            {
                c.enabled = false;
            }
            foreach (AudioSource s in audioSources)
            {
                s.enabled = false;
            }
        }
    }
}
