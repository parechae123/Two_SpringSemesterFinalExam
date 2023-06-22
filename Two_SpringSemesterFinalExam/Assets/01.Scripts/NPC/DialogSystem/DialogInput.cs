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
        yield return new WaitUntil(() => dialogSystem.UpdateDialog(0, true)); //��ٸ��� �Լ� , ���̾�α� �ý����� �Ϸ� �ɶ� ���� 
        //�μ��� ��� ��ȣ
    }
    private void Update()
    {
        if (Physics2D.OverlapCircle(transform.position, 2,128)&&!isDialogInputed)
        {
            isDialogInputed = true;
            Debug.Log("��ȭ�ڷ�ƾ ����");
            StartCoroutine(DialogStr());
        }
    }
}
