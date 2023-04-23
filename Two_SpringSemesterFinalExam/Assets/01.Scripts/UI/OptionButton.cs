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
        }
        else
        {
            SldrPanel.SetActive(false);
        }
    }
}
