using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonMonsterMoves : GeneralAnimations
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
    }
    public void Update()
    {
        Hit = Physics2D.Raycast(transform.position, Vector2.right*monsterDir, bc.bounds.extents.x + 0.7f, whatIsGround);
        plrHit = Physics2D.BoxCast(transform.position, bc.bounds.extents + (Vector3.right+Vector3.up)*2, 0, Vector2.up,0,128);
        atkDelay += Time.deltaTime;
        if (plrHit&&atkDelay > 2)
        {
            plrHit.collider.GetComponent<GeneralAnimations>().takeDamage(stat.atk, transform.position);
            atkDelay = 0;
            Debug.Log("¾Æ¾ß");
        }
        if (Hit)
        {
            monsterDir = monsterDir * -1;
        }
        rb.velocity = new Vector2(monsterDir * stat.moveSpeed,rb.velocity.y);
        MobFuncType();
    }
    protected virtual void MobFuncType()
    {

    }
}
