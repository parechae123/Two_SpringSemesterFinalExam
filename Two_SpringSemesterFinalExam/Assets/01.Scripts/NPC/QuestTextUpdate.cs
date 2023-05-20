using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestTextUpdate : MonoBehaviour
{
    public TextMeshProUGUI QuestText;
    private void Awake()
    {
        UIManager.Instance().QuestUI = this.gameObject;
        UIManager.Instance().UIStatck.Push(this.gameObject);
        gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    private void OnEnable()
    {
        if (UIManager.Instance().nowAcceptedMainQuest.questName == "")
        {
            QuestText.text = "";
        }
        else
        {
            QuestText.text = UIManager.Instance().nowAcceptedMainQuest.questName + "\n" + UIManager.Instance().nowAcceptedMainQuest.questText;
        }
        UIManager.Instance().UIStatck.Push(this.gameObject);
        Time.timeScale = 0;
    }
    private void OnDisable()
    {
        Time.timeScale = 1;
    }
}
