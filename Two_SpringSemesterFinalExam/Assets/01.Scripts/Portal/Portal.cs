using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] string StageName;
    [SerializeField] Vector3 nextStagePosition;
    private bool isPortalActivated = false;
    public GameObject keyArrow;
    public void PortalActivate()
    {
        if (!isPortalActivated)
        {
            isPortalActivated = true;
            GameManager.GMinstance().ChangeScene(StageName, true, nextStagePosition);
        }
    }
    private void Awake()
    {
        keyArrow.SetActive(false);
    }
    private void FixedUpdate()
    {
        if (Physics2D.OverlapBox(transform.position,Vector2.one*2,0,128))
        {
            if (!keyArrow.activeSelf)
            {
                keyArrow.SetActive(true);
            }
        }
        else
        {
            keyArrow.SetActive(false);
        }
    }
}
