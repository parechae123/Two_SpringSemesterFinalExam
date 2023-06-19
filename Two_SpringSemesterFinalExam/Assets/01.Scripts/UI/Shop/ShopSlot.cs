using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSlot : MonoBehaviour
{
    public BuyIconBase BuyManager;
    public items itemInfo;
    // Start is called before the first frame update
    public void OnBuyBTN()
    {
        if(InvenManager.InventoryInstance().playerGold-itemInfo.ItemValue >= 0)
        {
            InvenManager.InventoryInstance().GetItem(itemInfo, 1);
            InvenManager.InventoryInstance().playerGold -= itemInfo.ItemValue;
            InvenManager.InventoryInstance().GoldChanged();
        }
    }
}
