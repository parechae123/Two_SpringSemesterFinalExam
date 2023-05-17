using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Net.Http;


public class GameManager : MonoBehaviour
{
    #region ��������
    static GameManager GM;
    public SavedStats playerStatSave;
    public bool beenStatSaved = false;
    public Queue<GameObject> nonActivateArrows = new Queue<GameObject>();
    public Entity_MainQuests QuestInfo;
    public Entity_MainQuests.Param nowAcceptedMainQuest;
    public Entity_MainQuests.Param nowAcceptedSubQuest;
    public Stack<GameObject> UIStatck = new Stack<GameObject>();//���� UI �� ������� �������ֱ�
    public GameObject QuestUI;
    public EXPComps EXP;
    #endregion
    #region ����
    public struct SavedStats
    {
        public float jumpForce;
        public float moveSpeed;
        public int hp;
        public int atk;
        public byte jumpCount;
        public byte StatPoint;
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
    #region �̱��� ����
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
    #region ���� ����
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
    #region ����Ʈ 
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
        isQuestDone(isMainQuest);
    }
    public void isQuestDone(bool isMainQuest)
    {
        if (isMainQuest&&QuestUI.GetComponent<QuestTextUpdate>().QuestText.text.Contains(nowAcceptedMainQuest.questName))
        {
            if (nowAcceptedMainQuest.isQuestDone)
            {
                CompBTN.interactable = true;
                QuestUI.SetActive(true);
            }
            else
            {
                CompBTN.interactable = false;
            }
        }
        else if(!isMainQuest&& QuestUI.GetComponent<QuestTextUpdate>().QuestText.text.Contains(nowAcceptedSubQuest.questName))
        {
            if (nowAcceptedSubQuest.isQuestDone)
            {
                CompBTN.interactable = true;
                QuestUI.SetActive(true);
            }
            else
            {
                CompBTN.interactable = false;
            }
        }
    }
    public struct EXPComps
    {
        public byte nowLevel;
        public float nowExp;
    }
    #endregion
    #region ����ȯ
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
                beenStatSaved = true;
            }
        }
        UIStatck.Clear();
        yield return new WaitForSeconds(0.7f);
        SceneManager.LoadScene(StageName);
    }
    #endregion
    #region ����ġ ó��
    public Button CompBTN;
    public Slider ExpBar;
    public TMPro.TextMeshProUGUI LevelText;
    public void SetEXPBar(Slider expBar,TMPro.TextMeshProUGUI levelUI)
    {
        ExpBar = expBar;
        LevelText = levelUI;
        GetEXP(0);
    }
    public void GetEXP(float expAmount)
    {
        EXP.nowExp+= expAmount;
        ExpBar.value = EXP.nowExp;
        LevelText.text = "LV : " + EXP.nowLevel.ToString();
        //�������̺� �����ʿ�
    }
    #endregion
}
