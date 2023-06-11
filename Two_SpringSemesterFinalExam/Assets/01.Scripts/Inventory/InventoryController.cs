using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    public List<InventorySlot> slots = new List<InventorySlot>();
    private void Start()
    {
        gameObject.SetActive(false);
        InvenManager.InventoryInstance().SceneInvenSetting(this);
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
            if (item.itemInfo.ItemIndex == whatItem.ItemIndex && item.itemAmount - whatItemAmount >=0)
            {
                Debug.Log("������ �̸� ����");
                item.itemAmount -= whatItemAmount;
                item.itemInfoUpdate();
                break;
            }
        }
    }
    private void OnEnable()
    {
        UIManager.Instance().UIStatck.Push(this.gameObject);
    }
}
