using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Observer : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform owner;

    private bool _isPlayerInPOVRange = false;
    private bool _isPlayerSeen = false;

    void Start()
    {
        GetComponent<Collider>().isTrigger = true;
        GetComponent<Collider>().enabled = true;
        StartCoroutine(WaitForChangeState());
    }

    IEnumerator WaitForChangeState()
    {
        bool isPlayerSeen = _isPlayerSeen;
        yield return new WaitUntil(() => isPlayerSeen != _isPlayerSeen);
        if (_isPlayerSeen)
        {
            GameEvent.playerSaw.Invoke(owner.gameObject);
        }
        else
        {
            GameEvent.playerLostSight.Invoke(owner.gameObject);
        }

        StartCoroutine(WaitForChangeState());
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _isPlayerInPOVRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        //if (player != null)
            if (other.transform == player)
                _isPlayerInPOVRange = false;
    }

    void Update()
    {
        if (_isPlayerInPOVRange)
        {
            Vector3 direction = player.position - owner.transform.position + Vector3.up;

            if (Physics.Raycast(owner.transform.position, direction, out RaycastHit raycastHit))
            {
                Rigidbody hitRigidBody = raycastHit.rigidbody;
                if (hitRigidBody != null)
                {
                    //if (hitRigidBody.transform == player)
                    if (hitRigidBody.gameObject.layer == 13)
                    {
                        _isPlayerSeen = true; // See player
                        GameEvent.gotPlayer.Invoke(hitRigidBody.gameObject);
                        player = hitRigidBody.gameObject.transform;
                    }
                    return;
                }
                _isPlayerSeen = false; // Can't see player
            }
        }
    }
}
