using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum States
{
    Idle, Run, Jump, Attack, Damaged,
}
public class GeneralAnimations : StatSystem
{
    protected Animator anim;
    [SerializeField]protected States CharactorState;
    
    // Start is called before the first frame update
    protected virtual void StateUpdates(States newState)
    {
        StopCoroutine(CharactorState.ToString());
        anim.SetBool(CharactorState.ToString(), false);
        CharactorState = newState;
        StartCoroutine(CharactorState.ToString());

    }
    protected bool isInATKAnim()
    {
        if (CharactorState == States.Attack&&anim.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1.0f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void takeDamage(int Damage)
    {
        Debug.Log(Damage+"만큼 감소");
        base.stat.hp-= Damage;
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
    protected IEnumerator Attack()
    {
        /*anim.SetBool(CharactorState.ToString(), true);*/
        anim.Play("attack 0", 0);
        while (isInATKAnim())
        {
            yield return null;
        }
    }
    IEnumerator Damaged()
    {
        anim.SetBool(CharactorState.ToString() , true);
        yield return null;
    }
}
