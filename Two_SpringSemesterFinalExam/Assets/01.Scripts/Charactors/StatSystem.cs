using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatSystem : MonoBehaviour
{
    [SerializeField] public BaseStats stat;
    [System.Serializable]
    public struct BaseStats
    {
        public float jumpForce;
        public float moveSpeed;
        public int hp;
        public int atk;
    }
    protected virtual void SettingStats() 
    {
        stat.jumpForce = 5;
        stat.moveSpeed = 300;
        stat.hp = 100;
        stat.atk = 10;
    }
    protected virtual void SavePlrStats()
    {
        Debug.Log("세이브 완료");
        GameManager.GMinstance().playerStatSave.jumpForce = stat.jumpForce;
        GameManager.GMinstance().playerStatSave.moveSpeed = stat.moveSpeed;
        GameManager.GMinstance().playerStatSave.hp = stat.hp;
        GameManager.GMinstance().playerStatSave.atk = stat.atk;
        GameManager.GMinstance().playerStatSave.jumpCount = 0;
    }
    protected virtual void LoadPlrStats()
    {
        if (GameManager.GMinstance().beenStatSaved)
        {
            Debug.Log("로드 완료");
            stat.jumpForce = GameManager.GMinstance().playerStatSave.jumpForce;
            stat.moveSpeed = GameManager.GMinstance().playerStatSave.moveSpeed;
            stat.hp = GameManager.GMinstance().playerStatSave.hp;
            stat.atk = GameManager.GMinstance().playerStatSave.atk;
        }
    }
}
