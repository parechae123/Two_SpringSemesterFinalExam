using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : CommonMonsterMoves
{
    private void Awake()
    {
        base.SettingStats(35, 20, 3, 0);
        anim = GetComponent<Animator>();
        base.rb = GetComponent<Rigidbody2D>();
        base.bc = GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        base.WallSensedMoves(stat.moveSpeed);
    }
}
