using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowBTN : MonoBehaviour
{
    [SerializeField] private GameObject targetOBJ;
    // Start is called before the first frame update
    public void OnTargetBTN()
    {
        if (!targetOBJ.activeSelf)
        {
            targetOBJ.SetActive(true);
            UIManager.Instance().UIStatck.Push(targetOBJ);
        }
        else
        {
            targetOBJ.SetActive(false);
            if (UIManager.Instance().UIStatck.Count > 0)
            {
                UIManager.Instance().UIStatck.Pop();
            }
        }
    }
}
