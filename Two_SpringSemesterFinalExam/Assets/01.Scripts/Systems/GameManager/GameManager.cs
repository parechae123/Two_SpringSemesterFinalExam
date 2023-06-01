using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Net.Http;
using System.CodeDom.Compiler;


public class GameManager : MonoBehaviour
{
    #region º¯¼ö¹­À½
    static GameManager GM;
    [SerializeField]public SavedStats playerStatSave;
    public Queue<GameObject> nonActivateArrows = new Queue<GameObject>();
    #endregion
    #region ÀúÀå
    [System.Serializable]
    public struct SavedStats
    {
        public float jumpForce;
        public float moveSpeed;
        public int hp;
        public int maxHp;
        public int atk;
        public byte jumpCount;
        public byte StatPoint;
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
    }
    public void PlrStatusChange(string btnName)
    {
        if (playerStatSave.StatPoint > 0)
        {
            switch (btnName)
            {
                case "jumpForce":
                    playerStatSave.jumpForce += 1;
                    break;
                case "moveSpeed":
                    playerStatSave.moveSpeed += 1;
                    break;
                case "hp":
                    playerStatSave.maxHp += 1;
                    break;
                case "atk":
                    playerStatSave.atk += 1;
                    break;
            }
            playerStatSave.StatPoint -= 1;
            UIManager.Instance().StatusTextUpdate(btnName);
            if (GameObject.Find("Player").TryGetComponent<PlayerCTRL>(out PlayerCTRL PC))
            {
                PC.LoadPlrStats();
            }
            if (UIManager.Instance().nowAcceptedMainQuest.questName == "Æ©Åä¸®¾ó8: ½ºÅÝÆ÷ÀÎÆ®")
            {
                UIManager.Instance().nowAcceptedMainQuest.isQuestDone = true;
            }
            UIManager.Instance().HPValueChanged();
        }
    }
    #endregion
    #region ¾ÀÀüÈ¯
    public void ChangeScene(string StageName, bool isNextSceneMenu,Vector3 newPos)
    {
        StartCoroutine(ChangeSceneDelay(StageName,isNextSceneMenu,newPos));
    }
    IEnumerator ChangeSceneDelay(string StageName,bool isNextSceneMenu,Vector3 newPos)
    {
        if (GameObject.Find("Player"))
        {
            if(GameObject.Find("Player").TryGetComponent<PlayerCTRL>(out PlayerCTRL PC))
            {
                PC.SavePlrStats();
            }
        }
        UIManager.Instance().UIStatck.Clear();
        yield return new WaitForSeconds(0.7f);
        SceneManager.LoadScene(StageName);
        if (isNextSceneMenu)
        {
            SceneManager.LoadScene("PlayerScene", LoadSceneMode.Additive);
            nonActivateArrows.Clear();
            GameObject.Find("Player").transform.position = newPos;
        }
    }
    #endregion
}
