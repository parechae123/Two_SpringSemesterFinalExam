using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BuyIconBase : MonoBehaviour
{
    public List<Button> merchantIcons = new List<Button>();
    public List<items> iconByItem = new List<items>();
    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if(transform.GetChild(i).TryGetComponent<Button>(out Button BTN))
            {
                merchantIcons.Add(BTN);
                //�̸��� Ŭ������ �޾ƿ��°� �ѹ� ã�ƺ��ߵɵ�
            }
        }
    }
}
