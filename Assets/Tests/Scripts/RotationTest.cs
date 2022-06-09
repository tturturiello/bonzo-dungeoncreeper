using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTest : MonoBehaviour
{
    [SerializeField] private float axis;
    // Start is called before the first frame update
    void Start()
    {
        axis = transform.rotation.x;
        //GetComponent<Rigidbody>().velocity = Vector3.left * 50;

        //GetComponent<Rigidbody>().AddExplosionForce(1000f,
        //    Vector3.forward, 10f, 0f, ForceMode.Impulse);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
}
