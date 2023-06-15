using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum States
{
    Idle, Run, Jump, Attack, Damaged, Die
}
public class PlayerAnimations : StatSystem
{
    protected Animator anim;
    [SerializeField] protected States CharactorState;
    Vector3 knockBackValue;
    int damagedValue;

    // Start is called before the first frame update
    protected virtual void StateUpdates(States newState)
    {
        if (CharactorState != States.Die && CharactorState != newState)
        {
            StopCoroutine(CharactorState.ToString());
            anim.SetBool(CharactorState.ToString(), false);
            CharactorState = newState;
            StartCoroutine(CharactorState.ToString());
        }
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
    public void takeDamage(int Damage, Vector3 pos)//넉백
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
            SoundManager.Instance().SFXInput("Run");
            yield return new WaitForSeconds (SoundManager.Instance().DefaultLoad.SFXSource.clip.length-0.2f);
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
        base.stat.hp -= damagedValue;
        SavePlrStats();
        UIManager.Instance().HPValueChanged();
        if (stat.hp <= 0)
        {
            CharactorState = States.Die;
            anim.Play("Die", 0);
            yield return null;
            while (anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 0.8f)
            {
                yield return null;
                rb.velocity = Vector2.zero;
            }
            gameObject.SetActive(false);
            base.SettingStats(100, 20, 6, 100, 5);
            base.SavePlrStats();
            UIManager.Instance().GameOverCall();
        }
        SoundManager.Instance().SFXInput("PlayerDamaged");
        anim.Play(CharactorState.ToString(), 0);
        Debug.Log(damagedValue + "만큼 감소");
        Vector3 DamageDirection = transform.position - knockBackValue;
        rb.velocity = Vector2.zero;
        rb.velocity = new Vector2(DamageDirection.x * 6, Mathf.Abs(DamageDirection.y * 3));
        yield return new WaitForSeconds(0.2f);
        anim.Play("walk", 0);
        StateUpdates(States.Run);
        //여기 수정해야됨 넉백 이상함
    }
}
