using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// UI Assistent shows the key should be pressed in the game environment.
/// </summary>
public class UIAssistent : MonoBehaviour
{
    [SerializeField] private Canvas ui;

    public GameObject Pivot { get; set; } = null;

    private int offsetModifier = 1;


    void Awake()
    {
        GameEvent.playerPOVSwitched.AddListener(() => offsetModifier *= -1);
    }

    void Start()
    {
        GameEvent.nearItem.AddListener(OnNearItem);
        GameEvent.nearItem.Invoke(false, null);
        ui.enabled = false;
    }

    void Update()
    {
        StartCoroutine(MotionCanvas());
    }

    IEnumerator MotionCanvas()
    {
        yield return new WaitUntil(() => ui.enabled);

        var cameraPos = Camera.main.transform.position; 
        gameObject.transform.LookAt(cameraPos);
        Vector3 offset = offsetModifier * (Camera.main.transform.position - transform.position).normalized + Vector3.up;

        if (Pivot != null)
        {
            var pivotPos = Pivot.transform.position;
            //gameObject.transform.position = Pivot.transform.position + offset;
            gameObject.transform.position = Vector3.Lerp(pivotPos, pivotPos + offset, 50f);
        }
    }

    void OnNearItem(bool state, GameObject item)
    {
        if (item != null)
        {
            bool isItem = item.GetComponentInChildren<IInventoryItem>() != null;
            if (!isItem) return;
        }

        ui.enabled = state;
        Pivot = item;
    }
}
