using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBase : MonsterAnimations
{
    public Transform plrTR;
    public PlayerAnimations plrAnim;
    public float atkDelay;
    // Start is called before the first frame update
    protected void StartSetting()
    {
        StateSetter();
        rb = GetComponent<Rigidbody2D>();
        monsterCol = GetComponent<Collider2D>();
        MonsterSettingStats(190,15,3,190,5,60);
        dizzyGage = 30;
        plrTR = GameManager.GMinstance().plrStat.gameObject.transform;
        plrAnim = GameManager.GMinstance().plrStat.gameObject.GetComponent<PlayerAnimations>();
        if (this.GetType().ToString() != "DragonMan")
        {
            stateMachine.ChangeState(stateLists["Run"]);
        }
        stateLists["Die"].monsterType = this.GetType().ToString();
        stateLists["Damaged"].monsterType = this.GetType().ToString();
        stateLists.Add("Fly", new Fly());
        stateLists["Fly"].anim = GetComponent<Animator>();
        stateLists["Fly"].monsterType = this.GetType().ToString();
    }
    protected void UpdateFunc()
    {
        atkDelay += Time.deltaTime;
        RaycastHit2D hit = Physics2D.BoxCast(monsterCol.bounds.center, monsterCol.bounds.size,0, Vector2.zero, 2, 128);
        if (hit && atkDelay >2)
        {
            Debug.Log("레이캐스트 작동");
            plrAnim.takeDamage(stat.atk, transform.position);
            atkDelay = 0;
            Debug.Log("아야");
        }
        
    }
}
