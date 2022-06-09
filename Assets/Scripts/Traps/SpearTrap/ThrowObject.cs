using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowObject : MonoBehaviour
{
    [SerializeField] private Rigidbody shot;
    [SerializeField] private float timeDelay = 0.2f;
    [SerializeField] private int intensity = 50;
    [SerializeField] private bool isOn = false;

    private Vector3 direction;

    void Start()
    {
        direction = shot.transform.up;
        StartCoroutine(Shot());
    }

    IEnumerator Shot()
    {
        yield return new WaitUntil(() => isOn);
        //GetComponent<Rigidbody>().velocity = direction * intensity;
        shot.velocity = direction * intensity;
    }
}
