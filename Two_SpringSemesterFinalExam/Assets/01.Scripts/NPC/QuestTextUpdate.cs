using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestTextUpdate : DiaLogSystemParent
{
    private void Awake()
    {
        UIManager.Instance().QuestUI = this.gameObject;
        UIManager.Instance().UIStatck.Push(this.gameObject);
        gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    private void OnEnable()
    {
        StartCoroutine(TextTypingAct(UIManager.Instance().nowAcceptedMainQuest.questText.Length, UIManager.Instance().nowAcceptedMainQuest.questName, UIManager.Instance().nowAcceptedMainQuest.questText));
        Time.timeScale = 0;
        UIManager.Instance().UIStatck.Push(this.gameObject);
    }
    private void OnDisable()
    {
        Time.timeScale = 1;
    }
}
