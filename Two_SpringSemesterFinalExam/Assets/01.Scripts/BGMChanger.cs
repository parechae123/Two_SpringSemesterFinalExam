using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMChanger : MonoBehaviour
{
    [SerializeField] private string BGMname;
    void Start()
    {
        SoundManager.Instance().BGMInput(BGMname);
    }
}
