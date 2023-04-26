using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonMonsterMoves : GeneralAnimations
{
    [SerializeField]protected BoxCollider2D bc;
    [SerializeField] protected Rigidbody2D rb;
    [SerializeField] protected LayerMask whatIsGround;
    [SerializeField] protected SpriteRenderer sr;
    private RaycastHit2D Hit;
    private int monsterDir = 1;
    protected virtual void WallSensedMoves(float MonsterMoveSpeed)
    {
        Hit = Physics2D.Raycast(transform.position, Vector2.right*monsterDir, bc.bounds.extents.x + 0.1f, whatIsGround);
        Debug.DrawRay(transform.position, Vector2.right * monsterDir * (bc.bounds.extents.x + 0.1f));
        if (Hit)
        {
            monsterDir = monsterDir * -1;
        }
        rb.velocity = new Vector2(monsterDir * MonsterMoveSpeed,rb.velocity.y);
    }
}
