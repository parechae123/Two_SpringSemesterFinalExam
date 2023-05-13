using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TutorialMonster : Slime
{
    public Transform playerTR;
    private void Update()
    {
        if (Vector3.Distance(playerTR.position, transform.position) < 10)
        {
            if (GameManager.GMinstance().nowAcceptedMainQuest.questName == "튜토리얼4: 수색")
            {
                GameManager.GMinstance().nowAcceptedMainQuest.isQuestDone = true;
            }
        }
        if(base.stat.hp <= 0)
        {
            GetComponent<TutorialMonster>().enabled = false;
        }
    }
}
