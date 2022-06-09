using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Build system allows to check if it is possible to build a trap with the items
/// in the inventory. 
/// A unique sum of item's IDs represents a trap value. 
/// The sum of several ItemMask is always a unique sum of elements, 
/// even if the player has three identical items in his inventory.
/// </summary>
public static class BuildSystem
{
    public enum ItemMask
    {
        NONE = 0,
        RING_ROTATOR = 1,                   //     1
        WEAPON_HOLDER = RING_ROTATOR << 2,  //   100
        AXE = WEAPON_HOLDER << 2,           // 10000
        HAMMER = AXE << 2,                  // ...
        SPEAR_LAUNCHER = HAMMER << 2,
        SPEAR = SPEAR_LAUNCHER << 2,
        SAW_HOLDER = SPEAR << 2,
        SAW_BLADE = SAW_HOLDER << 2,
    }

    public enum TrapMask
    {
        NONE = 0,
        AXE_TRAP = ItemMask.AXE + ItemMask.RING_ROTATOR + ItemMask.WEAPON_HOLDER,
        HAMMER_TRAP = ItemMask.HAMMER + ItemMask.RING_ROTATOR + ItemMask.WEAPON_HOLDER,
        SPEAR_TRAP = ItemMask.SPEAR + ItemMask.SPEAR_LAUNCHER,
        SAW_TRAP = ItemMask.SAW_BLADE + ItemMask.SAW_HOLDER + ItemMask.SAW_HOLDER,
    }

    public static int InventoryMask { get; set; } = (int)ItemMask.NONE;
}
