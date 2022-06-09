using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingRotator : Trap, IInventoryItem
{
    [SerializeField] private Sprite image;

    public Sprite Image => image;

    public string Name => "RingRotator";

    public BuildSystem.ItemMask UID => BuildSystem.ItemMask.RING_ROTATOR;

    public bool IsMemberOfTrap() =>
        BuildSystem.InventoryMask == (int)BuildSystem.TrapMask.HAMMER_TRAP
        || BuildSystem.InventoryMask == (int)BuildSystem.TrapMask.AXE_TRAP;
}
