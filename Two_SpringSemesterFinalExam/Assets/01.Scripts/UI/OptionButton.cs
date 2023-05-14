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
            GameManager.GMinstance().UIStatck.Push(SldrPanel);
        }
        else
        {
            SldrPanel.SetActive(false);
            if (GameManager.GMinstance().UIStatck.Count > 0)
            {
                GameManager.GMinstance().UIStatck.Pop();
            }
        }
    }
}
