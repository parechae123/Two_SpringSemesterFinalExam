using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonMan : BossBase
{
    private SpriteRenderer sr;
    public Transform fireBallPoint;
    public string[] Patterns;
    public float breathDelay = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartSetting();
        sr = GetComponent<SpriteRenderer>();
        stateLists.Add("Dizzy", new MonsterDizzy());
        stateLists["Dizzy"].anim = GetComponent<Animator>();
        stateLists.Add("Dizzy", new MonsterAttack());
        stateLists["MonsterAttack"].anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateFunc();
        if(stateMachine.CharactorNowState == stateLists["Idle"]&& breathDelay >= Random.Range(2,6))
        {
            breathDelay = 0;

        }
    }
}
