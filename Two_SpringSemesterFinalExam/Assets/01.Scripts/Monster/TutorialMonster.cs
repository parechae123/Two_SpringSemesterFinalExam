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
        if (Vector3.Distance(playerTR.position, transform.position) < 12)
        {
            if (GameManager.GMinstance().nowAcceptedMainQuest.questName == "튜토리얼4: 수색")
            {
                GameManager.GMinstance().nowAcceptedMainQuest.isQuestDone = true;
                GameManager.GMinstance().isQuestDone(true);
            }
        }
        if(base.stat.hp <= 0)
        {
            GetComponent<TutorialMonster>().enabled = false;
        }
    }
}
