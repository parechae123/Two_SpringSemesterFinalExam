using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonMonsterMoves : MonsterAnimations
{
    [SerializeField] protected LayerMask whatIsGround;
    [SerializeField] protected SpriteRenderer sr;
    private float atkDelay;
    private RaycastHit2D Hit;
    private RaycastHit2D plrHit;
    private int monsterDir = 1;
    protected void MoveSetting()
    {
        StateSetter();
        whatIsGround = LayerMask.GetMask("Ground");
        stateMachine.ChangeState(stateLists["Run"]);
        stateLists["Die"].monsterType = this.GetType().ToString();
        stateLists["Damaged"].monsterType = this.GetType().ToString();
    }
    public void Update()
    {
        Hit = Physics2D.Raycast(transform.position, Vector2.right * monsterDir, monsterCol.bounds.extents.x + 1.5f, whatIsGround);
        plrHit = Physics2D.BoxCast(transform.position, monsterCol.bounds.extents * 2.2f, 0, Vector2.up, 0, 128);
        atkDelay += Time.deltaTime;
        if (plrHit && atkDelay > 2 && stateMachine.CharactorNowState != stateLists["Die"])
        {
            plrHit.collider.GetComponent<PlayerAnimations>().takeDamage(stat.atk, transform.position);
            atkDelay = 0;
            Debug.Log("¾Æ¾ß");
        }
        if (Hit)
        {
            rb.velocity = Vector2.zero;
            monsterDir = monsterDir * -1;
        }
        stateMachine.StateUpdate(this);
        if (stateMachine.CharactorNowState.animTimer())
        {
            rb.velocity = new Vector2(monsterDir * stat.moveSpeed, rb.velocity.y);
            if (rb.velocity.x != 0)
            {
                if (rb.velocity.x > 0)
                {
                    sr.flipX = false;
                }
                else if (rb.velocity.x < 0)
                {
                    sr.flipX = true;
                }
            }
        }
        MobFuncType();
    }
    protected virtual void MobFuncType()
    {

    }
}
