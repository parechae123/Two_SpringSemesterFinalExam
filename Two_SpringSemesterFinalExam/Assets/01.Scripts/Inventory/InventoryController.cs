using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    public List<Image> IconPositions = new List<Image>();
    private void Start()
    {
        InvenManager.InventoryInstance().SceneInvenSetting(this);
    }

    private void OnEnable()
    {
        UIManager.Instance().UIStatck.Push(this.gameObject);
    }
}
