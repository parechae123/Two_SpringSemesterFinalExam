using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CompleteBTN : MonoBehaviour
{

    private void Awake()
    {
        UIManager.Instance().CompBTN = this.GetComponent<Button>();
    }
    public void OnComplete()
    {
        if (UIManager.Instance().nowAcceptedMainQuest.isQuestDone)
        {
            UIManager.Instance().GetEXP(UIManager.Instance().nowAcceptedMainQuest.exeReward);
            UIManager.Instance().nowAcceptedMainQuest = UIManager.Instance().QuestInfo.sheets[0].list[10];
        }
        else if (UIManager.Instance().nowAcceptedSubQuest.isQuestDone)
        {
            UIManager.Instance().GetEXP(UIManager.Instance().nowAcceptedSubQuest.exeReward);
            UIManager.Instance().nowAcceptedMainQuest = UIManager.Instance().QuestInfo.sheets[0].list[5];
        }
        UIManager.Instance().QuestUI.SetActive(false);
    }
}
