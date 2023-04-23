using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    static GameManager GM;
    [SerializeField]public Loading DefaultLoad;
    public static GameManager GMinstance()
    {
        return GM;
    }
    private void Awake()
    {
        if (GM == null)
        {
            GM = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            if(GM != this)
            {
                Destroy(this.gameObject);
            }
        }
    }
    public void SoundVolume(float VolumeValue,bool isThisBGMSlider)
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
    public void ChangeScene(string StageName)
    {
        SceneManager.LoadScene(StageName);
    }
}
