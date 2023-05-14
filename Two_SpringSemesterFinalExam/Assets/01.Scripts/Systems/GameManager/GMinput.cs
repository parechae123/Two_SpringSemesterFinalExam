using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMinput : MonoBehaviour
{
    public void OnESCKey(UnityEngine.InputSystem.InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            if(GameManager.GMinstance().UIStatck.Count > 0)
            {
                GameManager.GMinstance().UIStatck.Pop().SetActive(false);
            }
        }
    }
}
