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
        SoundManager.Instance().SFXInput("Damaged"+"_"+monsterType);
    }
    public override void StateLive(MonsterAnimations MonsterAnimation)
    {
        if (animTimer())
        {
            if (this.GetType().ToString() == "DragonMan")
            {
                MonsterAnimation.stateMachine.ChangeState(MonsterAnimation.stateLists["Idle"]);
            }
            else if (this.GetType().ToString() != "DragonMan")
            {
                MonsterAnimation.stateMachine.ChangeState(MonsterAnimation.stateLists["Run"]);
            }
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
        InvenManager.InventoryInstance().playerGold += Random.Range(0,50);
        InvenManager.InventoryInstance().GoldChanged();
    }
    public override void StateLive(MonsterAnimations MonsterAnimation)
    {
        if (animTimer())
        {
            GameManager.GMinstance().respawnQ(MonsterAnimation.gameObject);
            MonsterAnimation.monsterCol.enabled = true;
            MonsterAnimation.rb.bodyType = RigidbodyType2D.Dynamic;
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
            Debug.Log(anim.GetCurrentAnimatorStateInfo(0).normalizedTime+"몬스터 마주함");
            MonsterAnimation.stateMachine.ChangeState(MonsterAnimation.stateLists["Run"]);
        }
    }
    public override void Exit()
    {

    }
}
public class Fly : MonsterStates
{
    public override void Enter()
    {
        anim.Play("Fly");
    }
    public override void StateLive(MonsterAnimations MonsterAnimation)
    {

    }
    public override void Exit()
    {

    }
}
public class MonsterDizzy : MonsterStates
{
    public override void Enter()
    {
        anim.Play("Dizzy");
    }
    public override void StateLive(MonsterAnimations MonsterAnimation)
    {
        if (animTimer())
        {
            Debug.Log(anim.GetCurrentAnimatorStateInfo(0).normalizedTime + "몬스터 마주함");
            MonsterAnimation.stateMachine.ChangeState(MonsterAnimation.stateLists["Idle"]);
        }
    }
    public override void Exit()
    {

    }
}
public class MonsterAttack : MonsterStates
{
    public override void Enter()
    {
        anim.Play("Attack");
    }
    public override void StateLive(MonsterAnimations MonsterAnimation)
    {
        if (animTimer())
        {
            MonsterAnimation.stateMachine.ChangeState(MonsterAnimation.stateLists["Idle"]);
            Debug.Log("");
        }
    }
    public override void Exit()
    {

    }
}
public class MonsterBreath : MonsterStates
{
    public override void Enter()
    {
        anim.Play("Breath");
    }
    public override void StateLive(MonsterAnimations MonsterAnimation)
    {
        if (animTimer())
        {
            MonsterAnimation.stateMachine.ChangeState(MonsterAnimation.stateLists["Idle"]);
        }
    }
    public override void Exit()
    {

    }
}