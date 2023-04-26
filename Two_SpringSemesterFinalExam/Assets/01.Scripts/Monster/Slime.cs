using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : CommonMonsterMoves
{
    private void Awake()
    {
        stat.moveSpeed = 3;
        stat.hp = 35;
        stat.atk = 20;
        anim = GetComponent<Animator>();
        base.rb = GetComponent<Rigidbody2D>();
        base.bc = GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        base.WallSensedMoves(stat.moveSpeed);
    }
}
