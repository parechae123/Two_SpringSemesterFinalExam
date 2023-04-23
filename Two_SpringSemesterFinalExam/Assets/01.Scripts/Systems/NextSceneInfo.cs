using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextSceneInfo : MonoBehaviour
{
    public string SceneName;
    public void NextScene()
    {
        GameManager.GMinstance().ChangeScene(SceneName);
    }
}
