using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
    [SerializeField] private Transform target;

    void Update()
    {
        gameObject.transform.LookAt(target);
        //gameObject.transform.rotation *= Quaternion.AngleAxis(180, Vector3.up);
    }
}
