using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundVolumeSlider : MonoBehaviour
{
    private Slider Slider;
    public bool isThisBGMSlider = false;
    private void Awake()
    {
        if(this.transform.name == "BGMSlider")
        {
            isThisBGMSlider=true;
        }
        Slider = GetComponent<Slider>();
    }
    public void OnSliderChanged()
    {
        float SliderValue = Slider.value;
        GameManager.GMinstance().SoundVolume(SliderValue, isThisBGMSlider);
    }
}
