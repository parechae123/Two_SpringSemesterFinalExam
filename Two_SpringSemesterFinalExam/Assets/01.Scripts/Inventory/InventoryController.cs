using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public List<InventorySlot> slots = new List<InventorySlot>();
    private void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            slots.Add(transform.GetChild(i).gameObject.GetComponent<InventorySlot>());
            slots[i].itemInfo = new NullSlot();
            slots[i].itemInfo.SetItemValues();
            Debug.Log(slots[i].itemInfo.ItemIndex);
        }
        InvenManager.InventoryInstance().invenSet = this;
        if (InvenManager.InventoryInstance().invenSetSave.Count > 0)
        {
            Debug.Log("�κ� ���� �Ⱥ������");
            InvenManager.InventoryInstance().InvenLoad();
        }
        else if (InvenManager.InventoryInstance().invenSetSave.Count <= 0)
        {
            Debug.Log("�κ� ���� �������");
            InvenManager.InventoryInstance().InvenSave();
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
