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
        if(itemAmount <= 0)
        {
            amountText.text = "";
            itemIcon.sprite = Resources.Load<Sprite>(itemInfo.iconPath);
        }
        //�� �Ѿ�� �κ��丮 ������Ʈ���� �� �ʱ�ȭ�� �ٸ� ������ ����
        //�̰� �������̺�� ��� �ȹް� JSON���� �Ű��ָ� �ɵ�?
    }
}
