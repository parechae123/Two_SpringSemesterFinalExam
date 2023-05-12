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
                if (GameManager.GMinstance().nowAcceptedMainQuest.questName == "" || GameManager.GMinstance().QuestInfo.sheets[0].list[Mathf.Clamp(questIndex - 1,0,1000)].isQuestDone)
                {
                    GameManager.GMinstance().GetQuestInfo(questIndex, isThisMainQuestTrigger);
                    gameObject.SetActive(false);
                }
            }
            else
            {
                GameManager.GMinstance().GetQuestInfo(questIndex, isThisMainQuestTrigger);
                gameObject.SetActive(false);
            }
        }
    }
}
