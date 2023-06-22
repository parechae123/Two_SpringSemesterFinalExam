using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SelectionBTN : MonoBehaviour
{
    // Start is called before the first frame update
    public DiaLogSystem dialogSystem;
    public TextMeshProUGUI Tcom;
    public void OnSelectionBTN()
    {
        if (Tcom.text.Contains("늑대"))
        {
            UIManager.Instance().GetQuestInfo(9, true);//늑대처치 퀘스트 인덱스
            dialogSystem.fromSellectionToNextDia();
        }
        else if (Tcom.text.Contains("슬라임"))
        {
            UIManager.Instance().GetQuestInfo(8,true);//슬라임 처치 퀘스트 인덱스
            dialogSystem.fromSellectionToNextDia();
        }
        
    }
}
