using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropBox : MonoBehaviour
{
    public int amounts;
    public SpriteRenderer ItemIMG;
    public items DropItemInfo;
    public void Awake()
    {
        amounts = Random.Range(1, 4);
        ItemIMG = GetComponent<SpriteRenderer>();
    }
    public void DropItemSetting(items monsterDrobsThis)
    {
        DropItemInfo = monsterDrobsThis;
        DropItemInfo.SetItemValues();
        ItemIMG.sprite = Resources.Load<Sprite>(DropItemInfo.iconPath);
    }
    public void ItemInteraction()
    {
        InvenManager.InventoryInstance().GetItem(DropItemInfo, amounts);
    }
}
