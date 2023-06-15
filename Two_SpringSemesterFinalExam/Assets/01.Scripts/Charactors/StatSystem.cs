using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatSystem : MonoBehaviour
{
    public Rigidbody2D rb;
    [SerializeField] public BaseStats stat;
    public float dizzyGage;
    [System.Serializable]
    public struct BaseStats
    {
        public float jumpForce;
        public float moveSpeed;
        public int hp;
        public int maxHp;
        public int atk;
        public byte jumpCount;
        public float exp;
    }
    protected virtual void SettingStats(int hp, int atk, float ms,int maxHP, float jf) 
    {
        stat.jumpForce = jf;
        stat.moveSpeed = ms;
        stat.hp = hp;
        stat.maxHp = maxHP;
        stat.atk = atk;
    }
    protected virtual void MonsterSettingStats(int hp, int atk, float ms, int maxHP, float jf,float exp)
    {
        stat.jumpForce = jf;
        stat.moveSpeed = ms;
        stat.hp = hp;
        stat.maxHp = maxHP;
        stat.atk = atk;
        stat.exp = exp;
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
        stat.jumpForce = GameManager.GMinstance().playerStatSave.jumpForce;
        stat.moveSpeed = GameManager.GMinstance().playerStatSave.moveSpeed;
        stat.hp = GameManager.GMinstance().playerStatSave.hp;
        stat.maxHp = GameManager.GMinstance().playerStatSave.maxHp;
        stat.atk = GameManager.GMinstance().playerStatSave.atk;
    }
}
