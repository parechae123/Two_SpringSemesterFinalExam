using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvenManager : MonoBehaviour
{
    public InventoryController invenSet;
    public List<InventorySlot> invenSetSave = new List<InventorySlot>();
    private static InvenManager inventoryInstance;
    public static InvenManager InventoryInstance()
    {
        return inventoryInstance;
    }

    private void Awake()
    {
        if (inventoryInstance == null)
        {
            inventoryInstance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            if (inventoryInstance != this)
            {
                Destroy(this);
            }
        }

    }
    public void InvenLoad()
    {
        if (invenSet !=null)
        {
            invenSet.slots = invenSetSave;
            foreach (var item in invenSet.slots)
            {
                item.itemInfoUpdate();
            }
        }
    }
    public void InvenSave()
    {
        if(invenSet != null)
        {
            invenSetSave = invenSet.slots;
        }
    }
}
