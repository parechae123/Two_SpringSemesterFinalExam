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
    #region ��������
    static GameManager GM;
    public SavedStats playerStatSave;
    public bool beenStatSaved = false;
    public Queue<GameObject> nonActivateArrows = new Queue<GameObject>();
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
                    playerStatSave.hp += 1;
                    break;
                case "atk":
                    playerStatSave.atk += 1;
                    break;
            }
            playerStatSave.StatPoint -= 1;
            UIManager.Instance().StatusTextUpdate(btnName);
            if (GameObject.Find("Player").TryGetComponent<PlayerCTRL>(out PlayerCTRL PC))
            {
                beenStatSaved = true;
                PC.LoadPlrStats();
            }
            if (UIManager.Instance().nowAcceptedMainQuest.questName == "Ʃ�丮��8: ��������Ʈ")
            {
                UIManager.Instance().nowAcceptedMainQuest.isQuestDone = true;
            }

        }
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
                PC.SavePlrStats();
                beenStatSaved = true;
            }
        }
        UIManager.Instance().UIStatck.Clear();
        yield return new WaitForSeconds(0.7f);
        SceneManager.LoadScene(StageName);
    }
    #endregion
}