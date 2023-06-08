using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItem : MonoBehaviour
{
    public void OnBTN()
    {
        HPpotion temp = new HPpotion();
        InvenManager.InventoryInstance().invenSet.GetItem(temp, 10);
    }
    public void OnSecondBTN()
    {
        HeadArmor temp = new HeadArmor();
        InvenManager.InventoryInstance().invenSet.GetItem(temp, 10);
    }
}
