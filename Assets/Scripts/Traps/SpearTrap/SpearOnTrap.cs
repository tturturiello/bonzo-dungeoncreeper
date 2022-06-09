using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearOnTrap : MonoBehaviour
{
    [SerializeField] private GameObject stickablePart;
    [SerializeField] private GameObject instance;

    private FixedJoint fixedJoint;
    private List<Collider> exclude;

    private void OnTriggerEnter(Collider other)
    {
        bool isEnvironment = other.gameObject.layer == 8;
        bool isCharacter = other.gameObject.layer == 10;
            
        if (isCharacter || isEnvironment)
        {
            AudioManager.AudioEvent.spearHit.Invoke(gameObject);
            if (isCharacter)
            {
                AudioManager.AudioEvent.spearHitEnemyFX.Invoke(gameObject);
            }
            instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
            fixedJoint = instance.AddComponent<FixedJoint>() as FixedJoint;
            fixedJoint.connectedBody = other.attachedRigidbody;
            foreach (var item in GetComponentsInChildren<Collider>())
            {
                item.enabled = false;
            }
        }
    }
}
