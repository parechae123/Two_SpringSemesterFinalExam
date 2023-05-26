using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;

public class NewGeneralAnimations : StatSystem
{
    protected Animator anim;
    [SerializeField] protected States CharactorState;
    Vector3 knockBackValue;
    int damagedValue;

    // Start is called before the first frame update
    protected virtual void StateUpdates(States newState)
    {
        if (CharactorState != States.Die)
        {
            FSMRemake(newState);
            FSMRemake(CharactorState);
            anim.SetBool(CharactorState.ToString(), false);
            CharactorState = newState;
            StartCoroutine(CharactorState.ToString());
        }
    }
    private bool isAlreadyFuncRun;
    protected void FSMRemake(States newState)//
    {
        isAlreadyFuncRun = true;
        if (isAlreadyFuncRun)
        {
            return;
        }
        anim.SetBool(CharactorState.ToString(), true);
        while (CharactorState == newState)
        {
            
        }
        isAlreadyFuncRun = false;
    }
    protected bool isInATKAnim()
    {
        if (CharactorState == States.Attack && anim.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1.0f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void takeDamage(int Damage, Vector3 pos)//³Ë¹é
    {
        damagedValue = Damage;
        knockBackValue = pos;
        StateUpdates(States.Damaged);
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
        if (stat.hp <= 0)
        {
            StateUpdates(States.Die);
        }
        anim.Play(CharactorState.ToString(), 0);
        Vector3 DamageDirection = transform.position - knockBackValue;
        base.stat.hp -= damagedValue;
        rb.velocity = Vector2.zero;
        rb.velocity = new Vector2(DamageDirection.x * 6, Mathf.Abs(DamageDirection.y * 3));
        yield return new WaitForSeconds(0.2f);
        anim.Play("walk", 0);
        StateUpdates(States.Run);
        //¿©±â ¼öÁ¤ÇØ¾ßµÊ ³Ë¹é ÀÌ»óÇÔ
    }
    IEnumerator DIe()
    {
        anim.Play("Die", 0);
        while (anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 0.8f)
        {
            yield return null;
            rb.velocity = Vector2.zero;
        }
        gameObject.SetActive(false);
        while (true)
        {
            yield return null;
        }
    }
}
