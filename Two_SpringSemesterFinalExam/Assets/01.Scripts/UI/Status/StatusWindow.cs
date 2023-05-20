using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEditor.Search;

public class StatusWindow : MonoBehaviour
{
    public TextMeshProUGUI statusPoint;
    public TextMeshProUGUI[] nowStatus;
    private void Start()
    {
        UIManager.Instance().SW = this;
    }
    private void OnEnable()
    {
        statusPoint.text = GameManager.GMinstance().playerStatSave.StatPoint.ToString();
        nowStatus[0].text = GameManager.GMinstance().playerStatSave.jumpForce.ToString();
        nowStatus[1].text = GameManager.GMinstance().playerStatSave.moveSpeed.ToString();
        nowStatus[2].text = GameManager.GMinstance().playerStatSave.hp.ToString();
        nowStatus[3].text = GameManager.GMinstance().playerStatSave.atk.ToString();
    }
}
