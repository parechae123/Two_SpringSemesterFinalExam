using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statbuttons : MonoBehaviour
{
    public void OnStatButtonClick()
    {
        string btnName = transform.name;
        if (GameManager.GMinstance().playerStatSave.StatPoint >0)
        {
            switch (btnName)
            {
                case "jumpForce":
                    if (GameObject.Find("Player").TryGetComponent<StatSystem>(out StatSystem jpStat))
                    {
                        jpStat.stat.jumpForce += 1;
                    }
                    break;
                case "moveSpeed":
                    if (GameObject.Find("Player").TryGetComponent<StatSystem>(out StatSystem msStat))
                    {
                        msStat.stat.moveSpeed += 1;
                    }
                    break;
                case "hp":
                    if (GameObject.Find("Player").TryGetComponent<StatSystem>(out StatSystem hpStat))
                    {
                        hpStat.stat.hp += 1;
                    }
                    break;
                case "atk":
                    if (GameObject.Find("Player").TryGetComponent<StatSystem>(out StatSystem atkStat))
                    {
                        atkStat.stat.atk += 1;
                    }
                    break;
            }
            if(UIManager.Instance().nowAcceptedMainQuest.questName == "Æ©Åä¸®¾ó9: ½ºÅÝÆ÷ÀÎÆ®")
            {
                UIManager.Instance().nowAcceptedMainQuest.isQuestDone = true;
            }
            GameManager.GMinstance().playerStatSave.StatPoint -= 1;
        }
    }
}
