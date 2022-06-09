using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : WeaponTrap, IInventoryItem
{
    [SerializeField] private Sprite image;

    public Sprite Image => image;

    public string Name => "Saw";

    public BuildSystem.ItemMask UID => BuildSystem.ItemMask.SAW_BLADE;

    public bool IsMemberOfTrap()
        => BuildSystem.InventoryMask == (int)BuildSystem.TrapMask.SAW_TRAP;
}
