using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void OnGameOverBTN()
    {
        SceneManager.LoadScene("MainMenu");
        foreach (var SheetNum in UIManager.Instance().QuestInfo.sheets)
        {
            int i = 0;
            foreach (var ListNum in UIManager.Instance().QuestInfo.sheets[i].list)
            {
                ListNum.isQuestDone = false;
            }
            i++;
        }
    }
}
