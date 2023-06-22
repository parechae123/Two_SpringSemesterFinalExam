using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Stack<GameObject> UIStatck = new Stack<GameObject>();//추후 UI 켠 순서대로 끄게해주기
    public GameObject QuestUI;
    public Entity_MainQuests QuestInfo;
    public Entity_MainQuests.Param nowAcceptedMainQuest;
    public Entity_MainQuests.Param nowAcceptedSubQuest;
    public Button CompBTN;
    public Slider ExpBar;
    public Slider HPBar;
    public TMPro.TextMeshProUGUI LevelText;
    public EXPComps EXP;
    public LevelTable LT;
    private static UIManager instance;
    public StatusWindow SW;
    public DiaLogSystem DiaSystem;
    public static UIManager Instance()
    {
        return instance;
    }
    void Start()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            if(instance != this)
            {
                Destroy(this);
            }
        }
    }
    public void StatusTextUpdate(string WhatIsThisStatus)
    {
        switch (WhatIsThisStatus)
        {
            case "jumpForce":
                SW.nowStatus[0].text = GameManager.GMinstance().playerStatSave.jumpForce.ToString();
                break;
            case "moveSpeed":
                SW.nowStatus[1].text = GameManager.GMinstance().playerStatSave.moveSpeed.ToString();
                break;
            case "hp":
                SW.nowStatus[2].text = GameManager.GMinstance().playerStatSave.maxHp.ToString();
                break;
            case "atk":
                SW.nowStatus[3].text = GameManager.GMinstance().playerStatSave.atk.ToString();
                break;
        }
        SW.statusPoint.text = GameManager.GMinstance().playerStatSave.StatPoint.ToString();
    }
    public void GetQuestInfo(int questIndex, bool isMainQuest)
    {
        if (isMainQuest)
        {
            nowAcceptedMainQuest = QuestInfo.sheets[0].list[questIndex];
        }
        else if (!isMainQuest)
        {
            nowAcceptedSubQuest = QuestInfo.sheets[1].list[questIndex];
        }
        QuestUI.SetActive(true);
        isQuestDone(false);
    }
    public void isQuestDone(bool isMainQuest)
    {
        if (isMainQuest && QuestUI.GetComponent<QuestTextUpdate>().targetText.text.Contains(nowAcceptedMainQuest.questName))
        {
            if (nowAcceptedMainQuest.isQuestDone)
            {
                CompBTN.interactable = true;
            }
            else
            {
                CompBTN.interactable = false;
            }
        }
        else if (!isMainQuest && QuestUI.GetComponent<QuestTextUpdate>().targetText.text.Contains(nowAcceptedSubQuest.questName))
        {
            if (nowAcceptedSubQuest.isQuestDone)
            {
                CompBTN.interactable = true;
            }
            else
            {
                CompBTN.interactable = false;
            }
        }
    }
    public void SetEXPBar(Slider expBar, TMPro.TextMeshProUGUI levelUI)
    {
        ExpBar = expBar;
        LevelText = levelUI;
        ExpBar.value = EXP.nowExp;
        LevelText.text = EXP.nowLevel.ToString();
        GetEXP(0);
    }
    public void GetEXP(float expAmount)
    {
        EXP.nowExp += expAmount;
        ExpBar.value += expAmount;
        if (ExpBar.value >= ExpBar.maxValue)
        {
            int PrevEXP = 0;
            int PrevLV = EXP.nowLevel;
            foreach (var LV in LT.sheets[0].list)
            {
                if (LV.EXP > EXP.nowExp)
                {
                    if (PrevEXP != 0)
                    {
                        LevelText.text = "LV : " + LV.Level.ToString();
                        EXP.nowLevel = LV.Level;
                        ExpBar.maxValue = LV.EXP - PrevEXP;
                        ExpBar.value = EXP.nowExp - PrevEXP;
                    }
                    int LVGap = (LV.Level-PrevLV)*5;
                    GameManager.GMinstance().playerStatSave.StatPoint += LVGap;
                    
                    if (EXP.nowExp<LV.EXP)
                    {
                        break;
                    }
                }
                PrevEXP = LV.EXP;
            }
        }
    }
    public void GameOverCall()
    {
         GameObject OverBTN= Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/UI/GameOver"),ExpBar.transform.parent );
    }
    public struct EXPComps
    {
        public int nowLevel;
        public float nowExp;
    }
    public void HPValueChanged()
    {
        HPBar.maxValue = GameManager.GMinstance().playerStatSave.maxHp;
        HPBar.value = GameManager.GMinstance().playerStatSave.hp;
    }
}
