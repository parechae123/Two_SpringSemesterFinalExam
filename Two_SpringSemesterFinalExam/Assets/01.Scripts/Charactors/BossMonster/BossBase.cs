using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBase : MonsterAnimations
{
    public Transform plrTR;
    // Start is called before the first frame update
    protected void StartSetting()
    {
        StateSetter();
        rb = GetComponent<Rigidbody2D>();
        monsterCol = GetComponent<Collider2D>();
        MonsterSettingStats(300,40,7,300,5,5000);
        plrTR = GameManager.GMinstance().plrStat.gameObject.transform;
    }
    protected void UpdateFunc()
    {
        transform.Translate(plrTR.position*Time.deltaTime*0.1f);
    }
}
