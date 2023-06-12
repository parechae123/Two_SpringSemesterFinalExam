using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItem : MonoBehaviour
{
    public void OnBTN()
    {
        HPpotion temp = new HPpotion();
        InvenManager.InventoryInstance().GetItem(temp, 125);
    }
    public void OnSecondBTN()
    {
        HeadArmor temp = new HeadArmor();
        InvenManager.InventoryInstance().GetItem(temp, 125);
    }
}
