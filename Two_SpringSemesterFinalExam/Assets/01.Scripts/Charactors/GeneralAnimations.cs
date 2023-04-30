using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum States
{
    Idle, Run, Jump, Attack, Damaged,
}
public class GeneralAnimations : StatSystem
{
    [SerializeField]protected Animator anim;

    protected States CharactorState;
    
    // Start is called before the first frame update
    protected virtual void StateUpdates(States newState)
    {
        StopCoroutine(CharactorState.ToString());
        anim.SetBool(CharactorState.ToString(), false);
        CharactorState = newState;
        StartCoroutine(CharactorState.ToString());
    }
    protected bool isInAttackAnim()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    IEnumerator Idle()
    {
        anim.SetBool(CharactorState.ToString(), true);
        while (true)
        {
            yield return null;
        }

    }
    IEnumerator Run()
    {
        anim.SetBool(CharactorState.ToString(), true);
        while (true)
        {
            yield return null;
        }
    }
    IEnumerator Jump()
    {
        anim.SetBool(CharactorState.ToString(), true);
        while (true)
        {
            yield return null;
        }
    }
    IEnumerator Attack()
    {
        anim.SetBool(CharactorState.ToString(), true);
        while (true)
        {
            yield return null;
        }
    }
    IEnumerator Damaged()
    {
        anim.SetBool(CharactorState.ToString() , true);
        while (true)
        {
            yield return null;
        }
    }
}
