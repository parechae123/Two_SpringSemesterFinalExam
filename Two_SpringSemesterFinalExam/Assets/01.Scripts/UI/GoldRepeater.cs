using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoldRepeater : MonoBehaviour
{
    public TextMeshProUGUI goldAmount;
    // Start is called before the first frame update
    void Awake()
    {
        goldAmount.text = InvenManager.InventoryInstance().playerGold.ToString();
        InvenManager.InventoryInstance().goldText = goldAmount;
    }

}
