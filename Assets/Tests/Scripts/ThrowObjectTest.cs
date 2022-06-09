using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowObjectTest : MonoBehaviour
{
    [SerializeField] private float timeDelay = 0.2f;
    [SerializeField] private int intensity = 50;
    [SerializeField] private Vector3 direction = Vector3.left;

    void Start()
    {
        Invoke(nameof(Shot), timeDelay);

    }

    void Shot()
    {
        GetComponent<Rigidbody>().velocity = direction * intensity;

        //GetComponent<Rigidbody>().AddExplosionForce(1000f,
        //    Vector3.forward, 10f, 0f, ForceMode.Impulse);
    }
}
