using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GMinput : MonoBehaviour
{
    public GameObject menuBar;
    public GameObject questUI;
    public GameObject charactorUI;
    public GameObject inventoryUI;
    public void OnESCKey(InputAction.CallbackContext ctx)
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
    public void OnQKey(InputAction.CallbackContext ctx)
    {
        if (questUI.activeSelf)
        {
            questUI.SetActive(false);
        }
        else
        {
            questUI.SetActive(true);
            UIManager.Instance().UIStatck.Push(questUI);
        }

    }
    public void OnIKey(InputAction.CallbackContext ctx)
    {
        if (inventoryUI.activeSelf)
        {
            inventoryUI.SetActive(false);
        }
        else
        {
            inventoryUI.SetActive(true);
            UIManager.Instance().UIStatck.Push(inventoryUI);
        }
    }
    public void OnCKey(InputAction.CallbackContext ctx)
    {
        if (charactorUI.activeSelf)
        {
            charactorUI.SetActive(false);
        }
        else
        {
            charactorUI.SetActive(true);
            UIManager.Instance().UIStatck.Push(charactorUI);
        }
    }
}
