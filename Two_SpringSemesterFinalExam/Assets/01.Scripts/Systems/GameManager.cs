using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager GM;
    public SavedStats playerStatSave;
    public bool beenStatSaved = false;
    public Queue<GameObject> nonActivateArrows = new Queue<GameObject>();
    public Entity_MainQuests QuestInfo;
    public Entity_MainQuests.Param nowAcceptedQuest;

    public struct SavedStats
    {
        public float jumpForce;
        public float moveSpeed;
        public int hp;
        public int atk;
        public byte jumpCount;
    }

    [SerializeField]public Loading DefaultLoad;
    [System.Serializable]
    public struct Loading
    {
        public AudioClip BGMList;
        public AudioSource BGMSource;
        public AudioSource SFXSource;
    }

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


    public void ChangeScene(string StageName)
    {
        StartCoroutine(ChangeSceneDelay(StageName));
    }


    IEnumerator ChangeSceneDelay(string StageName)
    {
        if (GameObject.Find("Player"))
        {
            if(GameObject.Find("Player").TryGetComponent<PlayerCTRL>(out PlayerCTRL PC))
            {
                PC.SaveUpdatedPlayerStat();
                /*base.SavePlrStats();*/
                beenStatSaved = true;
            }
        }
        yield return new WaitForSeconds(0.7f);
        SceneManager.LoadScene(StageName);
    }
}
