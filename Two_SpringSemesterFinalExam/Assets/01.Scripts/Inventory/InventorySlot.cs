using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
[System.Serializable]
public class InventorySlot
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
        if(itemAmount <= 0)
        {
            itemInfo = new NullSlot();
            amountText.text = "";
            itemIcon.sprite = Resources.Load<Sprite>(itemInfo.iconPath);
        }
        //씬 넘어갈때 인벤토리 컴포넌트들이 다 초기화됨 다른 저장방법 강구
        //이거 모노비헤이비어 상속 안받고 JSON으로 옮겨주면 될듯?
    }
}
