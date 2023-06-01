using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] string StageName;
    [SerializeField] Vector3 nextStagePosition;
    public void PortalActivate()
    {
        GameManager.GMinstance().ChangeScene(StageName,true, nextStagePosition);
    }
    public void PlayerNearPortal()
    {
        
    }
}
