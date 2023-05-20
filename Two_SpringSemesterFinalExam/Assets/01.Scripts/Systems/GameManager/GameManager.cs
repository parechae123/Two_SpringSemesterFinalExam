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
        UIManager.Instance().UIStatck.Clear();
        yield return new WaitForSeconds(0.7f);
        SceneManager.LoadScene(StageName);
    }
    #endregion
    #region ����ġ ó��


    #endregion
}
