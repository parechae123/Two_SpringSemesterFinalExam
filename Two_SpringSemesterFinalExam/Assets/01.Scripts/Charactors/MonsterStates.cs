using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class MonsterStates
{
    public Animator anim;
    public string monsterType;
    public items monsterOwnItem;
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
    public abstract void Enter();//�Ʒ����� �����ϴ� ��ũ��Ʈ���� �����Ҷ� enter�� ���ͼ�
    public abstract void StateLive(MonsterAnimations MonsterAnimation);
    public abstract void Exit();//Exit�� ���� �Ʒ����� 
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
        Debug.Log("��");
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
        SoundManager.Instance().SFXInput("Damaged"+"_"+monsterType);
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
        GameObject drobItem = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/ItemBox"), anim.transform.position, Quaternion.identity);
        ItemDropBox monsteritem = drobItem.GetComponent<ItemDropBox>();
        monsteritem.DropItemSetting(monsterOwnItem);
        anim.Play("Die");
        SoundManager.Instance().SFXInput("Die"+"_"+monsterType);
    }
    public override void StateLive(MonsterAnimations MonsterAnimation)
    {
        if (animTimer())
        {
            Debug.Log(anim.GetCurrentAnimatorStateInfo(0).normalizedTime);
            MonsterAnimation.gameObject.SetActive(false);
        }
        else
        {
            MonsterAnimation.monsterCol.enabled = false;
            MonsterAnimation.rb.bodyType = RigidbodyType2D.Kinematic;
            MonsterAnimation.rb.velocity = Vector3.zero;
        }
    }
    public override void Exit()
    {
        
    }
}
public class MobFindPlayer : MonsterStates
{
    public override void Enter()
    {
        anim.Play("Growling");
        SoundManager.Instance().SFXInput("Growling" +"_"+monsterType);
    }
    public override void StateLive(MonsterAnimations MonsterAnimation)
    {
        if (animTimer())
        {
            Debug.Log(anim.GetCurrentAnimatorStateInfo(0).normalizedTime+"���� ������");
            MonsterAnimation.stateMachine.ChangeState(MonsterAnimation.stateLists["Run"]);
        }
    }
    public override void Exit()
    {

    }
}
