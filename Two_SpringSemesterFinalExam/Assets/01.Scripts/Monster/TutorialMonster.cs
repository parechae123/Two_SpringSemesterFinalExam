using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;

public class TutorialMonster : CommonMonsterMoves
{
    public Transform playerTR;
    private void Awake()
    {
        base.MonsterSettingStats(35, 20, 3,35, 0,30);
        base.rb = GetComponent<Rigidbody2D>();
        monsterCol = GetComponent<BoxCollider2D>();
        base.sr = GetComponent<SpriteRenderer>();
        MonsterDropItem = new SlimeLiquid();
        MonsterDropItem.SetItemValues();
        MoveSetting();

    }
    private void Start()
    {
        playerTR = GameManager.GMinstance().plrStat.gameObject.transform;
    }
    protected override void MobFuncType()
    {
        if (Vector3.Distance(playerTR.position, transform.position) < 15)
        {
            if (UIManager.Instance().nowAcceptedMainQuest.questName == "튜토리얼4: 수색")
            {
                UIManager.Instance().nowAcceptedMainQuest.isQuestDone = true;
                UIManager.Instance().isQuestDone(true);
            }
        }
    }
}
