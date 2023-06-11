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
        
        for (int i = 0; i < 20; i++)
        {
            slots.Add(new InventorySlot());
            slots[i].amountText = invenControl.transform.GetChild(i).Find("AmountText").GetComponent<TextMeshProUGUI>();
            slots[i].flavorText = invenControl.transform.GetChild(i).Find("FlavorText").GetComponent<TextMeshProUGUI>();
            slots[i].itemIcon = invenControl.transform.GetChild(i).Find("Slot").GetComponent<Image>();
            slots[i].itemInfo = new NullSlot();
            slots[i].itemInfo.SetItemValues();
            Debug.Log(slots[i].itemInfo.ItemIndex);
        }

        gameObject.SetActive(false);
    }
    public void GetItem(items whatItem, int whatItemAmount)
    {
        whatItem.SetItemValues();
        foreach (var item in slots)
        {
            if (item.itemInfo.ItemIndex == whatItem.ItemIndex && item.itemAmount + whatItemAmount < 255)
            {
                Debug.Log("������ �̸� ����");
                item.itemAmount += whatItemAmount;
                item.itemInfoUpdate();
                break;
            }
            else if (item.itemInfo.ItemIndex == 0)//�κ�ĭ�� ������ ������ ������ �Ű������� ���� ������ �־��ְ� �̹����� ������ �־��ش�
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
        foreach (var item in slots)
        {
            if (item.itemInfo.ItemIndex == whatItem.ItemIndex && item.itemAmount - whatItemAmount >= 0)
            {
                Debug.Log("������ �̸� ����");
                item.itemAmount -= whatItemAmount;
                item.itemInfoUpdate();
                break;
            }
        }
    }

}
