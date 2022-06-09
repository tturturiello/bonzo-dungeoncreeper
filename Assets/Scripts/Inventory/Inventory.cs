using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private const int SLOTS = 3;

    [SerializeField] private Transform[] slots = new Transform[SLOTS];

    public Transform[] Slots { get => slots; set => slots = value; }
    public IInventoryItem[] Items { get; set; } = new IInventoryItem[SLOTS];


    public void AddItem(IInventoryItem item)
    {
        for (int i = 0; i < SLOTS; i++)
        {
            if (Items[i] == null)
            {
                Collider mCollider = (item as MonoBehaviour)
                    .GetComponent<Collider>();

                if(mCollider.enabled)
                {
                    mCollider.enabled = false;
                    Items[i] = item;
                    item.OnPickUp();
                }

                GameEvent.itemAdded.Invoke(item);
                GameEvent.nearItem.Invoke(false, null);

                break;
            }
        }
    }

    public void RemoveItem(int index, Vector3 position)
    {
        if (Items.Length > index && index > -1)
        {
            IInventoryItem item = Items[index];
            if (item != null)
            {
                RemoveItem(index);
                DropItem(item, position);
            }
        }
    }

    public void RemoveItem(int index)
    {
        IInventoryItem item = Items[index];
        Items[index] = null;
        GameEvent.itemRemoved.Invoke(index);
    }

    public void DropItem(IInventoryItem item, Vector3 position)
    {
        item.OnDrop(position);
        Collider coll = (item as MonoBehaviour).GetComponent<Collider>();
        if (coll != null) 
            coll.enabled = true;
        GameEvent.itemDropped.Invoke(item);
    }
}
