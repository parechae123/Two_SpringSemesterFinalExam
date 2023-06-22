using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTrigger : MonoBehaviour
{
    public byte questIndex;
    public bool isThisMainQuestTrigger;
    private void FixedUpdate()
    {
        if (Physics2D.Raycast(transform.position, Vector2.up, 100, 128/*2의 7승 플레이어는 7번이기 때문에 128이되나봄*/))
        {
            if (isThisMainQuestTrigger)
            {
                if (!UIManager.Instance().QuestInfo.sheets[0].list[0].isQuestDone)
                {
                    UIManager.Instance().GetQuestInfo(questIndex, isThisMainQuestTrigger);
                    gameObject.SetActive(false);
                }
                else if (UIManager.Instance().nowAcceptedMainQuest.questName == "None" && UIManager.Instance().QuestInfo.sheets[0].list[Mathf.Clamp(questIndex - 1,0,100)].isQuestDone)
                {
                    UIManager.Instance().GetQuestInfo(questIndex, isThisMainQuestTrigger);
                    gameObject.SetActive(false);
                }
            }
            else
            {
                UIManager.Instance().GetQuestInfo(questIndex, isThisMainQuestTrigger);
                gameObject.SetActive(false);
            }
        }
    }
}
