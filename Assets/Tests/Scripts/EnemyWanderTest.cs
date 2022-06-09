using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWanderTest : MonoBehaviour
{
    [SerializeField] private float speed = 20;
    [SerializeField] private float range = 20;

    private Vector3 wayPoint;
    private Vector3 startPoint;

    void Start()
    {
        startPoint = transform.position;
        Wander();
    }

    void Update()
    {
        transform.position += transform.TransformDirection(Vector3.forward)
            * speed * Time.deltaTime;
        transform.LookAt(wayPoint);
        if ((transform.position - wayPoint).magnitude <3)
            Wander();
        
    }

    private void Wander()
    {
        wayPoint = startPoint - Vector3.forward;
        wayPoint.y = 1;
    }
}
