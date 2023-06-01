using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundVolumeSlider : MonoBehaviour
{
    private Slider VSlider;
    public bool isThisBGMSlider = false;
    private void Awake()
    {
        VSlider = GetComponent<Slider>();
        if(this.transform.name == "BGMSlider")
        {
            isThisBGMSlider=true;
            VSlider.value = SoundManager.Instance().DefaultLoad.BGMSource.volume;
        }
        else if(transform.name == "SFXSlider")
        {
            VSlider.value = SoundManager.Instance().DefaultLoad.SFXSource.volume;
        }
        VSlider = GetComponent<Slider>();
    }
    public void OnSliderChanged()
    {
        float SValue = VSlider.value;
        SoundManager.Instance().SoundVolume(SValue, isThisBGMSlider);
    }
}
