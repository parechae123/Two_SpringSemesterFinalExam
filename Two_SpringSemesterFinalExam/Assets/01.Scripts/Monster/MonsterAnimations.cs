using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterAnimations : StatSystem
{
    Vector3 knockBackValue;
    int damagedValue;
    protected items MonsterDropItem;
    public StateMachine stateMachine;
    public Dictionary<string, MonsterStates> stateLists = new Dictionary<string, MonsterStates>();
    public Collider2D monsterCol;
    // Start is called before the first frame update
    public void StateSetter()
    {
        stateMachine = new StateMachine();
        stateLists.Add("Idle", new MonsterIdle());
        stateLists["Idle"].anim = GetComponent<Animator>();
        stateLists["Idle"].monsterOwnItem = MonsterDropItem;
        stateLists.Add("Die", new MonsterDie());
        stateLists["Die"].anim = GetComponent<Animator>();
        stateLists["Die"].monsterOwnItem = MonsterDropItem;
        stateLists.Add("Damaged", new MonsterDamaged());
        stateLists["Damaged"].anim = GetComponent<Animator>();
        stateLists.Add("Run", new MonsterRun());
        stateLists["Run"].anim = GetComponent<Animator>();
        if (this.GetType().ToString() != "DragonMan")
        {
            stateMachine.ChangeState(stateLists["Run"]);
        }
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

            if (this.GetType().ToString() == "DragonMan")
            {
                dizzyGage -= 10;
                if (dizzyGage <= 0)
                {
                    stateMachine.ChangeState(stateLists["Dizzy"]);
                }
            }
        }
        else
        {
            stateMachine.ChangeState(stateLists["Die"]);
            UIManager.Instance().GetEXP(stat.exp);
        }
    }
}
