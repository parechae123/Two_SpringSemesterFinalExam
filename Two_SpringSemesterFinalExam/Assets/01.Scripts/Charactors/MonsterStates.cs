using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MonsterStates
{
    public Animator anim;
    public abstract void Enter();//�Ʒ����� �����ϴ� ��ũ��Ʈ���� �����Ҷ� enter�� ���ͼ�
    public abstract void Exit();//Exit�� ���� �Ʒ����� 
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
