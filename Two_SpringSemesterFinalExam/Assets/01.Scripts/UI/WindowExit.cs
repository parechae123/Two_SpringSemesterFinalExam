using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowExit : MonoBehaviour
{
    public GameObject Target;
    public void OnClickWindowExit()
    {
        GameManager.GMinstance().nowAcceptedQuest = GameManager.GMinstance().QuestInfo.sheets[0].list[0];
        Debug.Log(GameManager.GMinstance().nowAcceptedQuest.questName);
        Target.SetActive(false);
    }
}
