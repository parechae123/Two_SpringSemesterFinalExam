using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMinput : MonoBehaviour
{
    public void OnESCKey(UnityEngine.InputSystem.InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            if(UIManager.Instance().UIStatck.Count > 0)
            {
                UIManager.Instance().UIStatck.Pop().SetActive(false);
            }
        }
    }
}
