using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(AudioSource))]
public class PlayOnTrigger : MonoBehaviour
{
    private bool hasAlreadyTriggered = false;

    void Awake()
    {
        GetComponent<Collider>().isTrigger = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!hasAlreadyTriggered)
            {
                GetComponent<AudioSource>().Play();
                hasAlreadyTriggered = true;
            }
        }
    }
}
