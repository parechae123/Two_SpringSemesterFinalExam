using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTrigger : MonoBehaviour
{
    public byte questIndex;
    public bool isThisMainQuestTrigger;
    private void FixedUpdate()
    {
        if (Physics2D.Raycast(transform.position, Vector2.up, 100, 128/*2�� 7�� �÷��̾�� 7���̱� ������ 128�̵ǳ���*/))
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
