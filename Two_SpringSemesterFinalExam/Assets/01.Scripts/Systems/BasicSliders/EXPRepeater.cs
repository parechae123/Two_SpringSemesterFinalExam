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
    public LevelTable LT;
    private void Awake()
    {
        expBar = GetComponent<Slider>();
        levelUI = GameObject.Find("LVText").GetComponent<TextMeshProUGUI>();
        UIManager.Instance().SetEXPBar(expBar, levelUI);
    }
}
