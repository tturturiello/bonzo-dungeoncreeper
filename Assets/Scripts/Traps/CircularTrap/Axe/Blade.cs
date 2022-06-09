using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") 
            || collision.gameObject.CompareTag("Enemy"))
        {
            AudioManager.AudioEvent.axeHit.Invoke(gameObject);
        }
    }
}
