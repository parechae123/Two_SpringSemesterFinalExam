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
        if (Tcom.text.Contains("����"))
        {
            UIManager.Instance().GetQuestInfo(9, true);//����óġ ����Ʈ �ε���
            dialogSystem.fromSellectionToNextDia();
        }
        else if (Tcom.text.Contains("������"))
        {
            UIManager.Instance().GetQuestInfo(8,true);//������ óġ ����Ʈ �ε���
            dialogSystem.fromSellectionToNextDia();
        }
        
    }
}
