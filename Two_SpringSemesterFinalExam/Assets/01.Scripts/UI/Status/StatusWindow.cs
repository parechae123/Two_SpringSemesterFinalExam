using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class StatusWindow : MonoBehaviour
{
    public TextMeshProUGUI statusPoint;
    public TextMeshProUGUI[] nowStatus;
    private void Awake()
    {
        statusPoint.text = GameManager.GMinstance().playerStatSave.StatPoint.ToString();
        nowStatus[0].text = GameManager.GMinstance().playerStatSave.jumpForce.ToString();
        nowStatus[1].text = GameManager.GMinstance().playerStatSave.moveSpeed.ToString();
        nowStatus[2].text = GameManager.GMinstance().playerStatSave.maxHp.ToString();
        nowStatus[3].text = GameManager.GMinstance().playerStatSave.atk.ToString();
        UIManager.Instance().SW = this;
        gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        statusPoint.text = GameManager.GMinstance().playerStatSave.StatPoint.ToString();
        nowStatus[0].text = GameManager.GMinstance().playerStatSave.jumpForce.ToString();
        nowStatus[1].text = GameManager.GMinstance().playerStatSave.moveSpeed.ToString();
        nowStatus[2].text = GameManager.GMinstance().playerStatSave.maxHp.ToString();
        nowStatus[3].text = GameManager.GMinstance().playerStatSave.atk.ToString();
    }
}
