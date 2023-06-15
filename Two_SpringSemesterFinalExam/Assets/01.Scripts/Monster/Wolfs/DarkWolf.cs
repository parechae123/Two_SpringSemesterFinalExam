using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkWolf : CommonMonsterMoves
{
    private bool isWolfPlayerFind = false;
    // Start is called before the first frame update
    void Awake()
    {
        MonsterSettingStats(50, 35, 5, 50, 10, 40);
        base.rb = GetComponent<Rigidbody2D>();
        monsterCol = GetComponent<BoxCollider2D>();
        base.sr = GetComponent<SpriteRenderer>();
        stateLists.Add("FindPlayer", new MobFindPlayer());
        stateLists["FindPlayer"].anim = GetComponent<Animator>();
        stateLists["FindPlayer"].monsterType = this.GetType().ToString();
        MonsterDropItem = new Bow();
        MonsterDropItem.SetItemValues();
        MoveSetting();
    }
    protected override void MobFuncType()
    {
        if (!isWolfPlayerFind&&stateMachine.CharactorNowState != stateLists["Die"])
        {
            if (Physics2D.OverlapCircle(transform.position, 5, 128))
            {
                isWolfPlayerFind = true;
                Debug.Log("플레이어 발견");
                stateMachine.ChangeState(stateLists["FindPlayer"]);
            } 
        }
    }
}
