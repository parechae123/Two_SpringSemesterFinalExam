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
            if (GameManager.GMinstance().nowAcceptedMainQuest.questName == "Ʃ�丮��4: ����")
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
