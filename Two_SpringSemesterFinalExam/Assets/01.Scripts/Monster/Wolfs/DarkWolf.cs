using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkWolf : CommonMonsterMoves
{
    // Start is called before the first frame update
    void Awake()
    {
        MonsterSettingStats(50, 35, 10, 50, 10, 40);
        base.rb = GetComponent<Rigidbody2D>();
        base.bc = GetComponent<BoxCollider2D>();
        base.sr = GetComponent<SpriteRenderer>();
        StateSetter();
        base.MoveSetting();
        stateLists.Add("FindPlayer", new MobFindPlayer());
        stateLists["FindPlayer"].anim = GetComponent<Animator>();

    }
    protected override void MobFuncType()
    {
        if (Physics2D.OverlapCircle(transform.position, 15, 128))
        {
            Debug.Log("플레이어 발견");
            stateMachine.ChangeState(stateLists["FindPlayer"]);
        }
    }
}
