using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonMonsterMoves : MonsterAnimations
{
    [SerializeField]protected BoxCollider2D bc;
    [SerializeField] protected LayerMask whatIsGround;
    [SerializeField] protected SpriteRenderer sr;
    private float atkDelay;
    private RaycastHit2D Hit;
    private RaycastHit2D plrHit;
    private int monsterDir = 1;
    private void Start()
    {
        whatIsGround =  LayerMask.GetMask("Ground");
        stateMachine.ChangeState(stateLists["Run"]);
        
    }
    public void Update()
    {
        Hit = Physics2D.Raycast(transform.position, Vector2.right*monsterDir, bc.bounds.extents.x + 1.5f, whatIsGround);
        plrHit = Physics2D.BoxCast(transform.position, bc.bounds.extents + (Vector3.right+Vector3.up)*2, 0, Vector2.up,0,128);
        atkDelay += Time.deltaTime;
        if (plrHit&&atkDelay > 2)
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
        if (!isDamagedMonster())
        {
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

        rb.velocity = new Vector2(monsterDir * stat.moveSpeed,rb.velocity.y);
        MobFuncType();
    }
    protected virtual void MobFuncType()
    {

    }
}
