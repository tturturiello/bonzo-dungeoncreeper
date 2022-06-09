using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawHolder : Trap, IInventoryItem
{
    [SerializeField] private Sprite image;

    public Sprite Image => image;

    public string Name => "SawHolder";

    public BuildSystem.ItemMask UID => BuildSystem.ItemMask.SAW_HOLDER;

    public bool IsMemberOfTrap() 
        => BuildSystem.InventoryMask == (int)BuildSystem.TrapMask.SAW_TRAP;
}
