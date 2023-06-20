using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;
using UnityEngine.UI;

public class InvenManager : MonoBehaviour
{
    public InventoryController invenControl;
    public List<InventorySlot> slots = new List<InventorySlot>();
    private static InvenManager inventoryInstance;
    public int playerGold;
    public TextMeshProUGUI goldText;
    public static InvenManager InventoryInstance()
    {
        return inventoryInstance;
    }

    private void Awake()
    {
        if (inventoryInstance == null)
        {
            inventoryInstance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            if (inventoryInstance != this)
            {
                Destroy(this);
            }
        }

    }
    public void SceneInvenSetting(InventoryController controllerGet)
    {
        invenControl = controllerGet;
        controllerGet.gameObject.SetActive(false);
        for (int i = 0; i < 20; i++)
        {
            if (slots.Count < 20)
            {
                slots.Add(new InventorySlot());
                slots[i].itemInfo = new NullSlot(); 
            }
            Debug.Log(slots[i].itemInfo);
            invenControl.transform.GetChild(i).GetComponent<InvenSlotInteraction>().slotIndex = i;
            slots[i].amountText = invenControl.transform.GetChild(i).Find("AmountText").GetComponent<TextMeshProUGUI>();
            slots[i].flavorText = invenControl.transform.GetChild(i).Find("FlavorText").GetComponent<TextMeshProUGUI>();
            slots[i].itemIcon = invenControl.transform.GetChild(i).Find("Slot").GetComponent<Image>();
            slots[i].itemInfo.SetItemValues();
            slots[i].itemInfoUpdate();
            Debug.Log(slots[i].itemInfo.ItemIndex);
        }
    }
    public void GetItem(items whatItem, int whatItemAmount)
    {
        whatItem.SetItemValues();
        foreach (var item in slots)
        {
            if (item.itemInfo.ItemIndex == whatItem.ItemIndex && item.itemAmount + whatItemAmount < 255)
            {
                Debug.Log("아이템 이름 같음");
                item.itemAmount += whatItemAmount;
                item.itemInfoUpdate();
                break;
            }
            else if (item.itemInfo.ItemIndex == 0)//인벤칸의 아이템 정보가 없을시 매개변수로 받은 정보를 넣어주고 이미지와 수량을 넣어준다
            {
                item.itemInfo = whatItem;
                item.itemAmount += whatItemAmount;
                item.itemInfoUpdate();
                break;
            }
        }
    }
    public void UseItem(items whatItem, int whatItemAmount)
    {
        Debug.Log(whatItem);
        foreach (var item in slots)
        {
            if (item.itemInfo.ItemIndex == whatItem.ItemIndex && item.itemAmount - whatItemAmount >= 0)
            {
                Debug.Log("아이템 이름 같음");
                item.itemAmount -= whatItemAmount;
                item.itemInfo.ItemEffect();
                item.itemInfoUpdate();
                break;
            }
        }
    }
    public void PlayerBuyItem(items targetItem)
    {
        if (InvenManager.InventoryInstance().playerGold - targetItem.ItemValue >= 0)
        {
            playerGold -= targetItem.ItemValue;
            GetItem(targetItem,1);
            GoldChanged();
        }


    }
    public void PlayerSellItem(int sellAmount,items targetItem)
    {
        playerGold += sellAmount;
        GoldChanged();
        targetItem.SetItemValues();
        foreach (var item in slots)
        {
            if (item.itemInfo.ItemIndex == targetItem.ItemIndex && item.itemAmount + 1 < 255)
            {
                Debug.Log("아이템 이름 같음");
                item.itemAmount += 1;
                item.itemInfoUpdate();
                break;
            }
            else if (item.itemInfo.ItemIndex == 0)//인벤칸의 아이템 정보가 없을시 매개변수로 받은 정보를 넣어주고 이미지와 수량을 넣어준다
            {
                item.itemInfo = targetItem;
                item.itemAmount += 1;
                item.itemInfoUpdate();
                break;
            }
        }
    }
    public void GoldChanged()
    {
        goldText.text = playerGold.ToString();
    }

}
