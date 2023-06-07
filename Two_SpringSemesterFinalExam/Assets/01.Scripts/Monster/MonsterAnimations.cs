using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterAnimations : StatSystem
{
    Vector3 knockBackValue;
    int damagedValue;
    public StateMachine stateMachine;
    public Dictionary<string, MonsterStates> stateLists = new Dictionary<string, MonsterStates>();
    public Collider2D monsterCol;
    // Start is called before the first frame update
    public void StateSetter()
    {
        stateMachine = new StateMachine();
        stateLists.Add("Die", new MonsterDie());
        stateLists["Die"].anim = GetComponent<Animator>();
        stateLists.Add("Damaged", new MonsterDamaged());
        stateLists["Damaged"].anim = GetComponent<Animator>();
        stateLists.Add("Run", new MonsterRun());
        stateLists["Run"].anim = GetComponent<Animator>();
        stateMachine.ChangeState(stateLists["Run"]);
    }
    public bool isDamagedMonster()
    {
        if (stateMachine.CharactorNowState == stateLists["Damaged"])
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool isHowling()
    {
        if (stateMachine.CharactorNowState == stateLists["Growling"])
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void takeDamage(int Damage,Vector3 pos)//³Ë¹é
    {
        stat.hp -= Damage;
        knockBackValue = pos;
        if (stat.hp>0)
        {
            stateMachine.ChangeState(stateLists["Damaged"]);
        }
        else
        {
            stateMachine.ChangeState(stateLists["Die"]);
            UIManager.Instance().GetEXP(stat.exp);
        }
    }
}
