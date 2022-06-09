using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupDropManager : MonoBehaviour
{
    [SerializeField] private Inventory inventory;

    private bool isNearItem = false;

    private GameObject lastItemGameObject = null; // it will avoid bugs

    private void Update()
    {
        StartCoroutine(WaitForDropItemInput());
    }

    private void OnTriggerEnter(Collider other)
    {
        IInventoryItem item = other.GetComponent<IInventoryItem>();
        if (IsItem(other))
        {
            if (lastItemGameObject != other.gameObject) // check for double trigger
            {
                lastItemGameObject = other.gameObject;
                ToggleIsNearItem(true, other.gameObject);
                StartCoroutine(WaitForPickUpInput(item));
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (lastItemGameObject == other.gameObject) // check for double trigger
        {
            ToggleIsNearItem(false, other.gameObject);
            lastItemGameObject = null;
        }
    }

    // collisions work better with GUI
    private void OnCollisionEnter(Collision other)
    {
        if (IsItem(other.collider))
            GameEvent.nearItem.Invoke(true, other.gameObject);
    }

    private void OnCollisionExit(Collision other)
    {
        if (IsItem(other.collider))
            GameEvent.nearItem.Invoke(false, other.gameObject);
    }

    private bool IsItem(Collider c)
    {
        return c.GetComponent<IInventoryItem>() != null;
    }


    void ToggleIsNearItem(bool state, GameObject item)
    {
        isNearItem = state;
    }

    IEnumerator WaitForPickUpInput(IInventoryItem item)
    {
        yield return new WaitUntil(() => PlayerInput.IsOnObjectActionPressed() 
            || !isNearItem
            );

        if (isNearItem)
            if (item != null)
                inventory.AddItem(item);
    }

    IEnumerator WaitForDropItemInput()
    {
        yield return new WaitUntil(PlayerInput.IsOnDropActionPressed);

        for (int i = 0; i < inventory.Slots.Length; i++)
        {
            bool isDroppable = inventory.Items[i] != null;
            if (PlayerInput.IsOnDropActionPressed(i) && isDroppable)
            {
                inventory.RemoveItem(i, (transform.gameObject
                    .GetComponent<PlayerMovement>().LocalForward));
                break;
            }
        }
    }
}
