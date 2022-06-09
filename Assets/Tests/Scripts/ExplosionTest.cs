using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionTest : MonoBehaviour
{
    [SerializeField] private float explosionDelay = 1.0f;
    [SerializeField] private float intensity = 10.0f;
    [SerializeField] private GameObject pointDirection;

    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(Explode), explosionDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Explode()
    {
        Vector3 direction = Vector3.forward;
        if (pointDirection)
        {
            direction = pointDirection.transform.position;
        }

        GetComponent<Rigidbody>().AddExplosionForce(intensity,
            direction, 10f, 0f, ForceMode.Impulse);
    }
}
