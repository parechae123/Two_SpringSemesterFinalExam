using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NextSceneInfo : MonoBehaviour
{
    public string SceneName;
    public int[] asdf;
    public void NextScene()
    {
        if (transform.name == "NewGame")        //뉴게임시 퀘스트 완료목록 초기화
        {
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
        GameManager.GMinstance().ChangeScene(SceneName,false,Vector3.zero);
    }
}
