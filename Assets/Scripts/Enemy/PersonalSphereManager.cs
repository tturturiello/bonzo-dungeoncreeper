using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class PersonalSphereManager : MonoBehaviour
{
    [SerializeField] private GameObject owner;

    void Start()
    {
        GetComponent<Collider>().isTrigger = true;
    }

    void OnTriggerEnter(Collider other)
    {
        bool isPlayer = other.gameObject.tag == "Player";
        //bool isPlayer = other.gameObject.transform == player;
        if (isPlayer)
        {
            //Debug.Log("SFERA PERSONALE: LANCIATO");
            GameEvent.playerCloseTo.Invoke(owner);
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            // TODO: avoid enemy on path
        }
    }

    void OnTriggerExit(Collider other)
    {
        bool isPlayer = other.gameObject.CompareTag("Player");
        if (other.gameObject.CompareTag("Player"))
        {
            GameEvent.playerFarAway.Invoke(owner);
        }
    }

    //private bool IsPlayerFar()
    //{
    //    return Mathf.Abs((player.transform.position - gameObject.transform.position)
    //        .magnitude) > 4f;
    //}
}
