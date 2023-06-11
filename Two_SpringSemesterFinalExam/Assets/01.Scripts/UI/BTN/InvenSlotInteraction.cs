using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class InvenSlotInteraction : MonoBehaviour
{
    public int slotIndex;
    public void OnItemClick()
    {
        InvenManager.InventoryInstance().UseItem(InvenManager.InventoryInstance().slots[slotIndex].itemInfo, 1);
    }
}
