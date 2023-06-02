using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] string StageName;
    [SerializeField] Vector3 nextStagePosition;
    private bool isPortalActivated = false;
    public void PortalActivate()
    {
        if (!isPortalActivated)
        {
            isPortalActivated = true;
            GameManager.GMinstance().ChangeScene(StageName, true, nextStagePosition);
        }
    }
    public void PlayerNearPortal()
    {
        
    }
}
