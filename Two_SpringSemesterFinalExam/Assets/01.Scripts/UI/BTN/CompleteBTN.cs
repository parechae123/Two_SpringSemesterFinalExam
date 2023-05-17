using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CompleteBTN : MonoBehaviour
{

    private void Awake()
    {
        GameManager.GMinstance().CompBTN = this.GetComponent<Button>();
    }
    public void OnComplete()
    {
        if (GameManager.GMinstance().nowAcceptedMainQuest.isQuestDone)
        {
            GameManager.GMinstance().GetEXP(GameManager.GMinstance().nowAcceptedMainQuest.exeReward);
            GameManager.GMinstance().nowAcceptedMainQuest = GameManager.GMinstance().QuestInfo.sheets[0].list[15];
        }
        else if (GameManager.GMinstance().nowAcceptedSubQuest.isQuestDone)
        {
            GameManager.GMinstance().GetEXP(GameManager.GMinstance().nowAcceptedSubQuest.exeReward);
            GameManager.GMinstance().nowAcceptedMainQuest = GameManager.GMinstance().QuestInfo.sheets[0].list[15];
        }
        GameManager.GMinstance().QuestUI.SetActive(false);
    }
}
