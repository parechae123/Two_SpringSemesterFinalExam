using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MonsterStates
{
    public Animator anim;
    public bool animTimer()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public abstract void Enter();//아래에서 구현하는 스크립트에서 시작할때 enter로 들어와서
    public abstract void StateLive(MonsterAnimations MonsterAnimation);
    public abstract void Exit();//Exit로 나감 아래에서 
}
public class MonsterIdle : MonsterStates
{
    public override void Enter()
    {
        anim.Play("Idle");
    }
    public override void StateLive(MonsterAnimations MonsterAnimation)
    {
        
    }
    public override void Exit()
    {

    }
}
public class MonsterRun : MonsterStates
{
    public override void Enter()
    {
        Debug.Log("런");
        anim.Play("Run");
    }
    public override void StateLive(MonsterAnimations MonsterAnimation)
    {

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
        Debug.Log("데미지드");
    }
    public override void StateLive(MonsterAnimations MonsterAnimation)
    {
        if (animTimer())
        {
            Debug.Log(anim.GetCurrentAnimatorStateInfo(0).normalizedTime);
            MonsterAnimation.stateMachine.ChangeState(MonsterAnimation.stateLists["Run"]);
        }
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
    public override void StateLive(MonsterAnimations MonsterAnimation)
    {

    }
    public override void Exit()
    {

    }
}
