using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSlot : MonoBehaviour
{
    public ShopPanel BuyManager;
    public items itemInfo;
    // Start is called before the first frame update
    public void OnBuyBTN()
    {
        InvenManager.InventoryInstance().PlayerBuyItem(itemInfo);
    }
}
