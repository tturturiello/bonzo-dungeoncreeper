using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// TODO: Gestire la collisione della lama con i layer. Mettere il layer del possessore
//dell-ascia con il layer dell'ascia. Questo layer chiamato tipo "ignore collision" 
//determina che non avviene la collisione con un'altro gameobject con questo layer.
// layer va messo su Axe e sul Character che la impugna.

public class Axe : WeaponTrap, IInventoryItem
{
    [SerializeField] private Sprite image;
    //[SerializeField] private AudioSource 

    public Sprite Image => image;

    public string Name => "Axe";

    public BuildSystem.ItemMask UID => BuildSystem.ItemMask.AXE;

    public bool IsMemberOfTrap() => 
        BuildSystem.InventoryMask == (int)BuildSystem.TrapMask.HAMMER_TRAP
        || BuildSystem.InventoryMask == (int)BuildSystem.TrapMask.AXE_TRAP;
}
