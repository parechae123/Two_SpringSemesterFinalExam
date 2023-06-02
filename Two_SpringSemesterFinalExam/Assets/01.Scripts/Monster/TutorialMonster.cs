using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;

public class TutorialMonster : Slime
{
    public Transform playerTR;
    private void Awake()
    {
        base.SettingStats(35, 20, 3,35, 0);
        base.rb = GetComponent<Rigidbody2D>();
        base.bc = GetComponent<BoxCollider2D>();
        base.sr = GetComponent<SpriteRenderer>();
        StateSetter();
        base.MoveSetting();
    }
    private void Start()
    {
        playerTR = GameObject.Find("Player").transform;
    }
    protected override void MobFuncType()
    {
        if (Vector3.Distance(playerTR.position, transform.position) < 7)
        {
            if (UIManager.Instance().nowAcceptedMainQuest.questName == "튜토리얼4: 수색")
            {
                UIManager.Instance().nowAcceptedMainQuest.isQuestDone = true;
                UIManager.Instance().isQuestDone(true);
            }
        }
    }
}
