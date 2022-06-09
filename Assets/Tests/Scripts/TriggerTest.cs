using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTest : MonoBehaviour
{
    void Start()
    {
        Debug.Log("started");
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Enter");
        //Destroy(gameObject);
    }       

    void OnTriggerExit()
    {
        Debug.Log("Trigger Exit");
    }
}
