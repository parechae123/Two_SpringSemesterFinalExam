using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MonsterStates
{
    public Animator anim;
    public abstract void Enter();//아래에서 구현하는 스크립트에서 시작할때 enter로 들어와서
    public abstract void Exit();//Exit로 나감 아래에서 
}
public class MonsterIdle : MonsterStates
{
    public override void Enter()
    {
        anim.Play("Idle");
    }
    public override void Exit()
    {

    }
}
public class MonsterRun : MonsterStates
{
    public override void Enter()
    {
        anim.Play("Run");
    }
    public override void Exit()
    {

    }
}
public class MonsterDamaged : MonsterStates
{
    public override void Enter()
    {
        anim.Play("Damaged");
    }
    public override void Exit()
    {

    }
}
public class MonsterDie : MonsterStates
{
    public override void Enter()
    {
        anim.Play("Die");
    }
    public override void Exit()
    {

    }
}
