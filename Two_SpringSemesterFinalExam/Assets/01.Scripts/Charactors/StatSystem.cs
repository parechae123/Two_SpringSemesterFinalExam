using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StatSystem : MonoBehaviour
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
    public abstract void SettingStats();//��ӹ޴� Ŭ�������� �� ��ü�� �̸�(��������)���� �ۼ��ʿ�
}
public class PlayerStat : StatSystem
{
    protected byte jumpCount;
    public override void SettingStats()
    {
        stat.jumpForce = 5;
        stat.moveSpeed = 300;
        stat.hp = 100;
        stat.atk = 10;
        jumpCount = 0;
    }
    public void SavePlrStats()
    {
        Debug.Log("���̺� �Ϸ�");
        GameManager.GMinstance().playerStatSave.jumpForce = stat.jumpForce;
        GameManager.GMinstance().playerStatSave.moveSpeed = stat.moveSpeed;
        GameManager.GMinstance().playerStatSave.hp = stat.hp;
        GameManager.GMinstance().playerStatSave.atk = stat.atk;
        GameManager.GMinstance().playerStatSave.jumpCount = 0;
    }
        public void LoadPlrStats()
    {
        if (GameManager.GMinstance().beenStatSaved)
        {
            Debug.Log("�ε� �Ϸ�");
            stat.jumpForce = GameManager.GMinstance().playerStatSave.jumpForce;
            stat.moveSpeed = GameManager.GMinstance().playerStatSave.moveSpeed;
            stat.hp = GameManager.GMinstance().playerStatSave.hp;
            stat.atk = GameManager.GMinstance().playerStatSave.atk;
            jumpCount = 0;
        }
    }
}
