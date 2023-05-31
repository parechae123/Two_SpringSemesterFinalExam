using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public Loading DefaultLoad;
    private static SoundManager instance;
    public static SoundManager Instance()
    {
        return instance;
    }
    void Start()
    {
        DefaultLoad.BGMSource = GetComponents<AudioSource>()[0];
        DefaultLoad.SFXSource = GetComponents<AudioSource>()[1];
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            if (instance != this)
            {
                Destroy(instance);
            }
        }
    }
    public void SoundVolume(float VolumeValue, bool isThisBGMSlider)
    {
        if (isThisBGMSlider)
        {
            DefaultLoad.BGMSource.volume = VolumeValue;
        }
        else
        {
            DefaultLoad.SFXSource.volume = VolumeValue;
        }
    }
    [System.Serializable]
    public struct Loading
    {
        public AudioClip BGMList;
        public AudioSource BGMSource;
        public AudioSource SFXSource;
    }
    public void SFXInput(string soundName)
    {
        DefaultLoad.SFXSource.clip = Resources.Load<AudioClip>("SFX/"+soundName);
        DefaultLoad.SFXSource.PlayOneShot(DefaultLoad.SFXSource.clip);
    }
    public void BGMInput(string soundName)
    {
        DefaultLoad.BGMSource.clip = Resources.Load<AudioClip>("BGM/"+soundName);
        DefaultLoad.BGMSource.Play();
    }
}
