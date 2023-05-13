using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestTextUpdate : MonoBehaviour
{
    public TextMeshProUGUI QuestText;
    private void Awake()
    {
        GameManager.GMinstance().QuestUI = this.gameObject;
        gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    private void OnEnable()
    {
        QuestText.text = GameManager.GMinstance().nowAcceptedMainQuest.questText;
        GameManager.GMinstance().UIQueue.Enqueue(this.gameObject);
        Time.timeScale = 0;
    }
    private void OnDisable()
    {
        Time.timeScale = 1;
    }
}
