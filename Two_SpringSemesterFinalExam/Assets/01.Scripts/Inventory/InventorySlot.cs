using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public items itemInfo;
    public int itemAmount = 0;
    public TextMeshProUGUI amountText;
    public TextMeshProUGUI flavorText;
    public Image itemIcon;
    public void itemInfoUpdate()
    {
        amountText.text = itemAmount.ToString();
        flavorText.text = itemInfo.flavorText;
        itemIcon.sprite = Resources.Load<Sprite>(itemInfo.iconPath);
        //씬 넘어갈때 인벤토리 컴포넌트들이 다 초기화됨 다른 저장방법 강구
    }
}
