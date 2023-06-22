using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogInput : MonoBehaviour
{
    [SerializeField]
    private DiaLogSystem dialogSystem;
    bool isDialogInputed = false;
    private IEnumerator DialogStr()
    {
        yield return new WaitUntil(() => dialogSystem.UpdateDialog(0, true)); //기다리는 함수 , 다이얼로그 시스템이 완료 될때 까지 
        //인수는 대사 번호
    }
    private void Update()
    {
        if (Physics2D.OverlapCircle(transform.position, 2,128)&&!isDialogInputed)
        {
            isDialogInputed = true;
            Debug.Log("대화코루틴 실행");
            StartCoroutine(DialogStr());
        }
    }
}
