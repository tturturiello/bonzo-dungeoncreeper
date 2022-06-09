using System;
using System.Collections;
using UnityEngine;

/// <summary>
/// It opens the associated door gameobject if the associated enemy are dead;
/// </summary>
public class OpenDoorManager : MonoBehaviour
{
    [SerializeField] private GameObject[] enemysKey;
    [SerializeField] private float rotationY = 50f;
    [SerializeField] private float stepForFrame = 0.1f;

    private GameObject doorObject;
    private int KeyDeathCounter;
    private float initialY;

    void Awake()
    {
        doorObject = gameObject;
        initialY = doorObject.transform.localRotation.eulerAngles.y;
        GameEvent.enemyDead.AddListener(owner => OnEnemyDeath(owner.GetInstanceID()));

        //OpenDoor(); // Toggle to test
    }

    void OnEnemyDeath(int ID)
    {
        foreach (var item in enemysKey)
        {
            if (item.GetInstanceID().Equals(ID))
            {
                KeyDeathCounter++;
                break;
            }
        }

        if (KeyDeathCounter >= enemysKey.Length)
        {
            StartCoroutine(WaitAndThen(OpenDoor, 1.2f));
        }
    }

    private void OpenDoor()
    {
        AudioManager.AudioEvent.doorOpened.Invoke(gameObject);
        StartCoroutine(WaitForDoorOpened());
    }

    IEnumerator WaitAndThen(Action action, float secs)
    {
        yield return new WaitForSeconds(secs);
        action.Invoke();
    }

    IEnumerator WaitForDoorOpened()
    {
        yield return new WaitForFixedUpdate();
        float step = -stepForFrame;
        doorObject.transform.Rotate(Vector3.up * step, Space.Self);
        //doorObject.transform.Rotate(Vector3.up * step);

        //doorObject.transform.SetPositionAndRotation(Quaternion.identity.SetEulerRotation(Vector3.up * step));

        float y = doorObject.transform.localRotation.eulerAngles.y;

        if (Mathf.Abs(y-initialY) < Mathf.Abs(rotationY))
        {
            StartCoroutine(WaitForDoorOpened());
        }
    }
}
