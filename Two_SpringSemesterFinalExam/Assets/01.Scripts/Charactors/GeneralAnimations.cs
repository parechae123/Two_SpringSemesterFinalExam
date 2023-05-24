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
    Vector3 knockBackValue;
    int damagedValue;
    
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
    public void takeDamage(int Damage,Vector3 pos)//넉백
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
        anim.SetBool(CharactorState.ToString() , true);
        Debug.Log(damagedValue + "만큼 감소");
        Vector3 DamageDirection = transform.position - knockBackValue;
        base.stat.hp -= damagedValue;
        Debug.Log(DamageDirection);
        rb.velocity = Vector2.zero;
        rb.velocity = new Vector2(DamageDirection.x * 6, Mathf.Abs(DamageDirection.y * 3));
        yield return new WaitForSeconds(0.2f);
        //여기 수정해야됨 넉백 이상함
    }
}
