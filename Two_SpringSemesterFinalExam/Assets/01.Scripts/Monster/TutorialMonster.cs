using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TutorialMonster : Slime
{
    public Transform playerTR;
    private void Awake()
    {
        base.SettingStats(35, 20, 3, 0);
        anim = GetComponent<Animator>();
        base.rb = GetComponent<Rigidbody2D>();
        base.bc = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        base.WallSensedMoves(stat.moveSpeed);
        if (Vector3.Distance(playerTR.position, transform.position) < 4)
        {
            if (UIManager.Instance().nowAcceptedMainQuest.questName == "튜토리얼4: 수색")
            {
                UIManager.Instance().nowAcceptedMainQuest.isQuestDone = true;
                UIManager.Instance().isQuestDone(true);
            }
        }
        if(base.stat.hp <= 0)
        {
            GetComponent<TutorialMonster>().enabled = false;
        }
    }
}
