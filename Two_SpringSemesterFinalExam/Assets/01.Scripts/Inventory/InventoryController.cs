using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    private void Start()
    {
        InvenManager.InventoryInstance().SceneInvenSetting(this);
    }
}
