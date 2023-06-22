using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonMan : BossBase
{
    private SpriteRenderer sr;
    public Transform[] fireBallPoint;
    public void HornFire()
    {
        GameObject FireBall = Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/fireball_01"), fireBallPoint[1].position, Quaternion.identity, null);
        FireBall.GetComponent<FireBall>().PlrTR = plrTR;
    }
    public void MouseFire()
    {
        GameObject FireBall = Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/fireball_01"), fireBallPoint[0].position, Quaternion.identity, null);
        FireBall.GetComponent<FireBall>().PlrTR = plrTR;
    }
    public string[] Patterns;
    public float breathDelay = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartSetting();
        MonsterDropItem = new HeadArmor();
        sr = GetComponent<SpriteRenderer>();
        stateLists.Add("Dizzy", new MonsterDizzy());
        stateLists["Dizzy"].anim = GetComponent<Animator>();
        stateLists.Add("MonsterAttack", new MonsterAttack());
        stateLists["MonsterAttack"].anim = GetComponent<Animator>();
        stateLists.Add("DragonBreath", new MonsterBreath());
        stateLists["DragonBreath"].anim = GetComponent<Animator>();
        stateMachine.ChangeState(stateLists["Idle"]);
    }
    
    // Update is called once per frame
    void Update()
    {
        UpdateFunc();
  
        Debug.Log(Random.Range(0, 2));
        if(stateMachine.CharactorNowState == stateLists["Idle"])
        {
            breathDelay += Time.deltaTime;
            if (breathDelay >= Random.Range(4, 9))
            {
                breathDelay = 0;
                stateMachine.ChangeState(stateLists[Patterns[Random.Range(0,2)]]);
            }
        }
        stateMachine.StateUpdate(this);
        stateMachine.ChangeState(stateLists["Idle"]);
        Debug.Log(Patterns[Random.Range(0, 2)]);
/*        Debug.Log(stateMachine.CharactorNowState);*/
    }

}
