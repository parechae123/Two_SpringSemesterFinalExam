using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterAnimations : StatSystem
{
    Vector3 knockBackValue;
    int damagedValue;
    protected StateMachine stateMachine;
    protected Dictionary<string, MonsterStates> stateLists = new Dictionary<string, MonsterStates>();
    // Start is called before the first frame update
    void Start()
    {
        stateMachine = new StateMachine();
        StateSetter();
    }
    void StateSetter()
    {
        stateLists.Add("Die", new MonsterDie());
        stateLists["Die"].anim = GetComponent<Animator>();
        stateLists.Add("Damaged", new MonsterDamaged());
        stateLists["Damaged"].anim = GetComponent<Animator>();
        stateLists.Add("Run", new MonsterRun());
        stateLists["Run"].anim = GetComponent<Animator>();
        stateMachine.ChangeState(stateLists["MonsterRun"]);
    }
    void Update()
    {
        stateMachine.StateUpdate();
        if (rb.velocity.x!= 0)
        {
            stateMachine.ChangeState(stateLists["run"]);
        }
        else if (rb.velocity.x == 0)
        {
            stateMachine.ChangeState(stateLists["Damaged"]);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            stateMachine.ChangeState(stateLists["Die"]);
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
    public void takeDamage(int Damage,Vector3 pos)//³Ë¹é
    {
        damagedValue = Damage;
        knockBackValue = pos;
        
    }
}
