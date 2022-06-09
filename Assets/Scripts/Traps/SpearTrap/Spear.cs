using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : WeaponTrap, IInventoryItem
{
    [SerializeField] private Sprite image;

    public Sprite Image => image;

    public string Name => "Spear";

    public BuildSystem.ItemMask UID => BuildSystem.ItemMask.SPEAR;

    public bool IsMemberOfTrap()
        => BuildSystem.InventoryMask == (int)BuildSystem.TrapMask.SPEAR_TRAP;
}
