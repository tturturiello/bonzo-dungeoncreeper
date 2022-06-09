using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildTrapManager : MonoBehaviour
{
    [SerializeField] private Inventory inventory;

    [SerializeField] private GameObject axeBlueprint;
    [SerializeField] private GameObject hammerBlueprint;
    [SerializeField] private GameObject sawBlueprint;
    [SerializeField] private GameObject spearBlueprint;

    private GameObject currBlueprint;

    void Awake()
    {
        GameEvent.itemAdded.AddListener(OnItemAdded);
        GameEvent.itemDropped.AddListener(OnItemDropped);
        GameEvent.trapBuilt.AddListener(OnTrapBuilt);
    }

    // increment inventoryMask and check if it is equal to any trap-mask
    private void OnItemAdded(IInventoryItem item)
    {
        BuildSystem.InventoryMask += (int)item.UID;
        ToggleBlueprint();
    }


    // TODO: Disattivare il blueprint
    private void OnItemDropped(IInventoryItem item)
    {
        BuildSystem.InventoryMask -= (int)item.UID;
        ToggleBlueprint();
    }

    private void OnTrapBuilt()
    {
        for (int i = 0; i < inventory.Items.Length; i++)
        {
            IInventoryItem item = inventory.Items[i];
            if (item.IsMemberOfTrap())
                inventory.RemoveItem(i);
        }
        BuildSystem.InventoryMask = (int)BuildSystem.TrapMask.NONE;
    }

    private void ToggleBlueprint()
    {
        switch (BuildSystem.InventoryMask)
        {
            case (int)BuildSystem.TrapMask.AXE_TRAP:
                currBlueprint = Instantiate(axeBlueprint);
                break;

            case (int)BuildSystem.TrapMask.HAMMER_TRAP:
                currBlueprint = Instantiate(hammerBlueprint);
                break;

            case (int)BuildSystem.TrapMask.SPEAR_TRAP:
                currBlueprint = Instantiate(spearBlueprint);
                break;

            case (int)BuildSystem.TrapMask.SAW_TRAP:
                currBlueprint = Instantiate(sawBlueprint);
                break;

            default:
                Destroy(currBlueprint);
                break;
        }
        if (currBlueprint != null)
            currBlueprint.SetActive(true);
    }
}
