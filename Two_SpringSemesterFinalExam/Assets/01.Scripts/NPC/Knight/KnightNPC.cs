using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightNPC : MonoBehaviour
{
    public bool isPlayerAttach;
    public GameObject targetUI;

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, 3, Vector2.zero, 1, 128);
        if (hit&&!isPlayerAttach)
        {
            isPlayerAttach = true;
            targetUI.SetActive(true);
            Debug.Log("しし");
        }
        else if(!hit&&isPlayerAttach)
        {
            isPlayerAttach = false;

            if (targetUI.activeSelf== true)
            {
                UIManager.Instance().UIStatck.Pop();
                targetUI.SetActive(false);
            }
            Debug.Log("いい");
        }
    }
}
