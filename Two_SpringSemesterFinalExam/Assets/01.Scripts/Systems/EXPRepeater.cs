using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EXPRepeater : MonoBehaviour
{
    private Slider expBar;
    private TextMeshProUGUI levelUI;
    public byte level;
    public float exp;
    private void Awake()
    {
        expBar = GetComponent<Slider>();
        levelUI = GameObject.Find("LVText").GetComponent<TextMeshProUGUI>();
        expBar.value = GameManager.GMinstance().EXP.nowExp;
        levelUI.text = "LV : "+GameManager.GMinstance().EXP.nowLevel.ToString();
    }
}
