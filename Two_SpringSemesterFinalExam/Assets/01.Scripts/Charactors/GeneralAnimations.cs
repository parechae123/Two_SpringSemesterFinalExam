using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralAnimations : StatSystem
{
    [SerializeField]protected Animator anim;
    protected enum States
    {
        Idle,Run,Jump,Attack,Damaged,
    }
    protected States CharactorState;
    
    // Start is called before the first frame update
    protected virtual void StateUpdates()
    {
        switch (CharactorState)
        {
            case States.Idle:
                break;
            case States.Run:
                break;
            case States.Jump:
                break;
            case States.Attack:
                break;
            case States.Damaged:
                break;
        }
    }

    protected virtual void IdleAnims()
    {
        //�̰� ������ �غ��� FSM ���� �ٸ� ������Ʈ���� ���� �ʿ�
    }
    protected virtual void RunAnims()
    {

    }
    protected virtual void JumpAnim()
    {

    }
    protected virtual void AttackAnim()
    {

    }
    protected virtual void DamagedAnim()
    {

    }
}
