using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Net.Http;

public class GameManager : MonoBehaviour
{
    #region º¯¼ö¹­À½
    static GameManager GM;
    public SavedStats playerStatSave;
    public bool beenStatSaved = false;
    public Queue<GameObject> nonActivateArrows = new Queue<GameObject>();
    public Entity_MainQuests QuestInfo;
    public Entity_MainQuests.Param nowAcceptedMainQuest;
    public Entity_MainQuests.Param nowAcceptedSubQuest;
    public Queue<GameObject> UIQueue = new Queue<GameObject>();//ÃßÈÄ UI ÄÒ ¼ø¼­´ë·Î ²ô°ÔÇØÁÖ±â
    public GameObject QuestUI;
    public EXPComps EXP;
    #endregion
    #region ÀúÀå
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
    #endregion
    #region ½Ì±ÛÅæ ¼¼ÆÃ
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
        GameManager.GMinstance().QuestInfo.sheets[0].list[0].isQuestDone = false;
    }
    #endregion
    #region »ç¿îµå ¼¼ÆÃ
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
    #endregion
    #region Äù½ºÆ® 
    public void GetQuestInfo(int questIndex, bool isMainQuest)
    {
        if (isMainQuest)
        {
            nowAcceptedMainQuest = QuestInfo.sheets[0].list[questIndex];
        }
        else if (!isMainQuest)
        {
            nowAcceptedSubQuest = QuestInfo.sheets[1].list[questIndex];
        }
        QuestUI.SetActive(true);
    }
    public bool isQuestSuccese()
    {
        if (nowAcceptedMainQuest.isQuestDone)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public struct EXPComps
    {
        public byte nowLevel;
        public float nowExp;
    }
    #endregion
    #region ¾ÀÀüÈ¯
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
    #endregion
    #region

    #endregion
}
