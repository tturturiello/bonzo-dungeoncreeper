using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : WeaponTrap, IInventoryItem
{
    [SerializeField] private Sprite image;

    public Sprite Image => image;

    public string Name => "Hammer";

    public BuildSystem.ItemMask UID => BuildSystem.ItemMask.HAMMER;

    public bool IsMemberOfTrap() =>
        BuildSystem.InventoryMask == (int)BuildSystem.TrapMask.HAMMER_TRAP
        || BuildSystem.InventoryMask == (int)BuildSystem.TrapMask.AXE_TRAP;
}
