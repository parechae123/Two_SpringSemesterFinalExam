using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMinput : MonoBehaviour
{
    public GameObject menuBar;
    public void OnESCKey(UnityEngine.InputSystem.InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            if(UIManager.Instance().UIStatck.Count > 0)
            {
                UIManager.Instance().UIStatck.Pop().SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                Time.timeScale = 0;
                if (menuBar == null)
                {
                    menuBar = Instantiate(Resources.Load<GameObject>("Prefabs/UI/Menu"),GameObject.Find("Canvas").transform);
                    menuBar.SetActive(true);
                }
                else
                {
                    if (!menuBar.activeSelf)
                    {
                        menuBar.SetActive(true);
                        Time.timeScale = 0;
                    }
                    else
                    {
                        menuBar.SetActive(false);
                        Time.timeScale = 1;
                    }
                }
            }
        }
    }
}
