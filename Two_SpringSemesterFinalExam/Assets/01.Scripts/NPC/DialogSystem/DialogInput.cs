using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogInput : MonoBehaviour
{
    [SerializeField]
    private DiaLogSystem dialogSystem;
    private IEnumerator Start()
    {
        yield return new WaitUntil(() => dialogSystem.UpdateDialog(0, true)); //기다리는 함수 , 다이얼로그 시스템이 완료 될때 까지 
        //인수는 대사 번호
    }
}
