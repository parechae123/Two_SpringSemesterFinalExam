using Michsky.UI.Shift;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionButton : MonoBehaviour
{
    public GameObject SldrPanel;
    public void OnButtonSliderActive()
    {
        if(SldrPanel.activeSelf == false)
        {
            SldrPanel.SetActive(true);
            UIManager.Instance().UIStatck.Push(SldrPanel);
        }
        else
        {
            SldrPanel.SetActive(false);
            if (UIManager.Instance().UIStatck.Count > 0)
            {
                UIManager.Instance().UIStatck.Pop();
            }
        }
    }
}
