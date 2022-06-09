using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balance : MonoBehaviour
{
    [Header("Distance Settings")]
    [SerializeField] private float thresholdDistance = 0.05f;

    private Vector3 balanceCheck = Vector3.down;
    private RaycastHit hit;

    void Update()
    {
        StartCoroutine(WaitForFall());
    }

    IEnumerator WaitForFall()
    {
        yield return new WaitWhile(() =>
            Physics.Raycast(transform.position, balanceCheck, out hit, thresholdDistance));

        GameEvent.characterFell.Invoke(gameObject);
    }
}
