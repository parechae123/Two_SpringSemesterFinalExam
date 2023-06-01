using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] string StageName;
    public void PortalActivate()
    {
        GameManager.GMinstance().ChangeScene(StageName,true);
    }
    public void PlayerNearPortal()
    {
        
    }
}
