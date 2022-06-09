using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Each class that implement this interface has to have a name an image and
/// an implementation of OnPickUp that is called when an item is collected 
/// by the player.
/// </summary>
public interface IInventoryItem
{
    string Name { get; }

    Sprite Image { get; }

    BuildSystem.ItemMask UID { get; }

    //BuildSystem.TrapMask Member { get; }
    bool IsMemberOfTrap();

    void OnPickUp();

    void OnDrop(Vector3 position);
}
