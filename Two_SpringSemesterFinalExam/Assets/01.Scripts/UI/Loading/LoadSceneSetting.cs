using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneSetting : MonoBehaviour
{
    public Slider LoadingBar;
    public Image loadingIMG;
    // Update is called once per frame
    private void Awake()
    {
        int IMGnumber = UnityEngine.Random.Range(1,6);
        LoadingBar.value = 0;
        loadingIMG.sprite = Resources.Load<Sprite>("LoadingIlusts/Loading"+IMGnumber.ToString());
    }

    public void SceneGate(string StageName, Vector3 newPos)
    {
        StartCoroutine(NextScene(StageName, newPos));
    }

    public IEnumerator NextScene(string StageName, Vector3 newPos)
    {
        AsyncOperation isNextSceneReady = SceneManager.LoadSceneAsync(StageName, LoadSceneMode.Additive);
        isNextSceneReady.allowSceneActivation = false;
        while (isNextSceneReady.progress < 0.89)
        {
            LoadingBar.value = isNextSceneReady.progress;
            yield return null;
        }
        while (LoadingBar.value < 1)
        {
            LoadingBar.value += 0.01f; 
            yield return null;
        }
        SceneManager.LoadScene("PlayerScene", LoadSceneMode.Additive);
        isNextSceneReady.allowSceneActivation = true;
        yield return null;
        GameObject.Find("Player").transform.position = newPos;
        Destroy(Camera.main.gameObject);
        Camera.main.gameObject.GetComponent<CameraControll>().ChangeBGsprite(StageName);
        SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("LoadingScene"));

    }
}
