using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField] private Inventory inventory;

    //[SerializeField] private Sprite voidSprite;

    // TODO: set canvas scaler to the size of the screen
    void Start()
    {
        GameEvent.itemAdded.AddListener(OnItemAdded);
        GameEvent.itemRemoved.AddListener(OnItemRemoved);
    }

    private void OnItemAdded(IInventoryItem item)
    {
        foreach (Transform slot in inventory.Slots)
        {
            Transform imageTransform = slot.GetChild(0).GetChild(0);
            Image image = imageTransform.GetComponent<Image>();

            // an empty slot is found
            if (!image.enabled)
            {
                image.enabled = true;
                image.sprite = item.Image;

                break;
            }
        }
    }

    private void OnItemRemoved(int index)
    {
        RemoveItem(index);
    }

    public void RemoveItem(int index)
    {
        var slot = inventory.Slots[index];
        Transform imageTransform = slot.GetChild(0).GetChild(0);
        Image image = imageTransform.GetComponent<Image>();
        image.enabled = false;
        //image.sprite = voidSprite;
    }
}
