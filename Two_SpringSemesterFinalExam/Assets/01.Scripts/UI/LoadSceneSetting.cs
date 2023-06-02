using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneSetting : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator NextScene(string StageName,Vector3 newPos)
    {
        float loadingTimer = 0;
        AsyncOperation isNextSceneReady = SceneManager.LoadSceneAsync(StageName);
        SceneManager.LoadSceneAsync("PlayerScene", LoadSceneMode.Additive);
        while (!isNextSceneReady.isDone)
        {
            loadingTimer += Time.deltaTime;
            yield return null;
            Debug.Log(isNextSceneReady.progress);
        }
        if (loadingTimer < 1)
        {
            while (loadingTimer < 2)
            {
                yield return null;
                loadingTimer += Time.deltaTime;
                Debug.Log(isNextSceneReady.progress);
            }
        }
        GameObject.Find("Player").transform.position = newPos;
    }
}
