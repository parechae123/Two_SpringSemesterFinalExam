using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatSystem : MonoBehaviour
{
    protected Rigidbody2D rb;
    [SerializeField] public BaseStats stat;
    [System.Serializable]
    public struct BaseStats
    {
        public float jumpForce;
        public float moveSpeed;
        public int hp;
        public int maxHp;
        public int atk;
        public byte jumpCount;
    }
    protected virtual void SettingStats(int hp, int atk, float ms,int maxHP, float jf) 
    {
        stat.jumpForce = jf;
        stat.moveSpeed = ms;
        stat.hp = hp;
        stat.maxHp = maxHP;
        stat.atk = atk;
    }
    public virtual void SavePlrStats()
    {
        GameManager.GMinstance().playerStatSave.jumpForce = stat.jumpForce;
        GameManager.GMinstance().playerStatSave.moveSpeed = stat.moveSpeed;
        GameManager.GMinstance().playerStatSave.hp = stat.hp;
        GameManager.GMinstance().playerStatSave.maxHp = stat.maxHp;
        GameManager.GMinstance().playerStatSave.atk = stat.atk;
        GameManager.GMinstance().playerStatSave.jumpCount = 0;
    }
    public virtual void LoadPlrStats()
    {
        if (GameManager.GMinstance().beenStatSaved)
        {
            stat.jumpForce = GameManager.GMinstance().playerStatSave.jumpForce;
            stat.moveSpeed = GameManager.GMinstance().playerStatSave.moveSpeed;
            stat.hp = GameManager.GMinstance().playerStatSave.hp;
            stat.maxHp = GameManager.GMinstance().playerStatSave.maxHp;
            stat.atk = GameManager.GMinstance().playerStatSave.atk;
            GameManager.GMinstance().beenStatSaved = false;
        }
    }
}
