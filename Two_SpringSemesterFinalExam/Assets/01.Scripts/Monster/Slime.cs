using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : CommonMonsterMoves
{
    private void Awake()
    {
        base.MonsterSettingStats(35, 20, 3,35, 0,30);
        base.rb = GetComponent<Rigidbody2D>();
        monsterCol = GetComponent<BoxCollider2D>();
    }
}
