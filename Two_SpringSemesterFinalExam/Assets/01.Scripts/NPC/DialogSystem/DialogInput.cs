using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogInput : MonoBehaviour
{
    [SerializeField]
    private DiaLogSystem dialogSystem;
    private IEnumerator Start()
    {
        yield return new WaitUntil(() => dialogSystem.UpdateDialog(0, true)); //��ٸ��� �Լ� , ���̾�α� �ý����� �Ϸ� �ɶ� ���� 
        //�μ��� ��� ��ȣ
    }
}
