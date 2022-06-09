using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Trap : MonoBehaviour
{

    public void OnDrop(Vector3 position)
    {
        gameObject.transform.SetPositionAndRotation(position, Quaternion.identity);
        //gameObject.transform.position = position;
        gameObject.SetActive(true);
    }

    public void OnPickUp()
    {
        gameObject.SetActive(false);
    }
}
