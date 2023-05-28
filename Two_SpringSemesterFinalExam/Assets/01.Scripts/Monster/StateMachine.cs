using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    public MonsterStates CharactorNowState;
    public MonsterStates CharactorNextState;
    public void ChangeState(MonsterStates newState)
    {
        if (CharactorNowState != null)
        {
            CharactorNowState.Exit();
        }

        CharactorNextState = newState;
    }
    public void StateUpdate()
    {
        if (CharactorNextState != null)
        {
            CharactorNowState = CharactorNextState;
            CharactorNowState.Enter();
            CharactorNextState = null;
        }
    }
}
