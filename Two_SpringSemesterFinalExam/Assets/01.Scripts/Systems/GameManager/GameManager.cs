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
    #region ∫Øºˆπ≠¿Ω
    static GameManager GM;
    [SerializeField] public SavedStats playerStatSave;
    public Queue<GameObject> nonActivateArrows = new Queue<GameObject>();
    #endregion
    #region ¿˙¿Â
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
    #region ΩÃ±€≈Ê ºº∆√
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
            if (GM != this)
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
            Debug.Log("Ω∫≈›©ê¿Ω");
            playerStatSave.StatPoint -= 1;
            Debug.Log(playerStatSave.StatPoint);
            UIManager.Instance().StatusTextUpdate(btnName);
            if (GameObject.Find("Player").TryGetComponent<PlayerCTRL>(out PlayerCTRL PC))
            {
                PC.LoadPlrStats();
            }
            if (UIManager.Instance().nowAcceptedMainQuest.questName == "∆©≈‰∏ÆæÛ8: Ω∫≈›∆˜¿Œ∆Æ")
            {
                UIManager.Instance().nowAcceptedMainQuest.isQuestDone = true;
                UIManager.Instance().isQuestDone(true);
            }
            UIManager.Instance().HPValueChanged();
        }
    }
    #endregion
    #region æ¿¿¸»Ø
    public void ChangeScene(string StageName, bool isNextSceneMenu, Vector3 newPos)
    {
        StartCoroutine(ChangeSceneDelay(StageName, isNextSceneMenu, newPos));
    }
    IEnumerator ChangeSceneDelay(string StageName, bool isNextSceneMenu, Vector3 newPos)
    {
        yield return null;
        if (GameObject.Find("Player"))
        {
            if (GameObject.Find("Player").TryGetComponent<PlayerCTRL>(out PlayerCTRL PC))
            {
                PC.SavePlrStats();
            }
        }
        UIManager.Instance().UIStatck.Clear();
        nonActivateArrows.Clear();
        if (isNextSceneMenu)
        {
            SceneManager.LoadScene("LoadingScene");
            yield return null;
            GameObject.Find("LoadingSceneManager").GetComponent<LoadSceneSetting>().SceneGate(StageName,newPos);
        }
        else
        {
            SceneManager.LoadScene(StageName);
        }

    }
    #endregion
}
