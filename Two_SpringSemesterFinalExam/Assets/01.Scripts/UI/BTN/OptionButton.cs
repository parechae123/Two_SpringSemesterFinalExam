using Michsky.UI.Shift;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionButton : MonoBehaviour
{
    private GameObject SldrPanel;
    public void OnButtonSliderActive()
    {
        if (SldrPanel == null)
        {
            SldrPanel = Instantiate(Resources.Load<GameObject>("Prefabs/UI/SoundSliders"), GameObject.Find("Canvas").transform);
            UIManager.Instance().UIStatck.Push(SldrPanel);
            SldrPanel.SetActive(true);
        }
        else if(SldrPanel.activeSelf)
        {
            SldrPanel.SetActive(false);
            if (UIManager.Instance().UIStatck.Count > 0)
            {
                UIManager.Instance().UIStatck.Pop();
            }
        }
        else
        {
            SldrPanel.SetActive(true);
            UIManager.Instance().UIStatck.Push(SldrPanel);
        }
    }
}
