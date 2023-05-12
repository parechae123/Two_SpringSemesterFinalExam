using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestLog : MonoBehaviour
{
    public void GetQuestLog()
    {
        GameManager.GMinstance().nowAcceptedQuest = GameManager.GMinstance().QuestInfo.sheets[0].list[0];
        Debug.Log(GameManager.GMinstance().nowAcceptedQuest.questName);
    }
}
