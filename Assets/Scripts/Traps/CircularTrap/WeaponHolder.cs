using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : Trap, IInventoryItem
{
    [SerializeField] private Sprite image;

    public Sprite Image => image;

    public string Name => "WeaponHolder";

    public BuildSystem.ItemMask UID => BuildSystem.ItemMask.WEAPON_HOLDER;

    public bool IsMemberOfTrap() =>
        BuildSystem.InventoryMask == (int)BuildSystem.TrapMask.HAMMER_TRAP
        || BuildSystem.InventoryMask == (int)BuildSystem.TrapMask.AXE_TRAP;
}
