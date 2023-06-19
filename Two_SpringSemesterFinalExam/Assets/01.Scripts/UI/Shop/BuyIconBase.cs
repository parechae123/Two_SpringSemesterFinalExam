using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BuyIconBase : MonoBehaviour
{
    public List<ShopSlot> merchantIcons = new List<ShopSlot>();
    private GameObject storeUI;
    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if(transform.GetChild(i).gameObject.TryGetComponent<ShopSlot>(out ShopSlot output))
            {
                merchantIcons.Add(output);
            }
        }
        merchantIcons[0].itemInfo = new Bow();
        merchantIcons[1].itemInfo = new HPpotion();
        merchantIcons[2].itemInfo = new SlimeLiquid();
        merchantIcons[3].itemInfo = new HeadArmor();
        for (int i = 0; i < merchantIcons.Count; i++)
        {
            merchantIcons[i].itemInfo.SetItemValues();
            merchantIcons[i].transform.GetChild(0).gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>(merchantIcons[i].itemInfo.iconPath);
        }
        storeUI = this.gameObject;
        storeUI.SetActive(false);
    }
}
