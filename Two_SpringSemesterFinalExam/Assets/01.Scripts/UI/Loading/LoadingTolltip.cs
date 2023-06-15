using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadingTolltip : MonoBehaviour
{
    public string[] TextIndex;
    public TextMeshProUGUI Text;
    // Start is called before the first frame update
    void Awake()
    {
        Text = GetComponent<TextMeshProUGUI>();
        Text.text = "�˰� ��˳���?"+"\n"+TextIndex[Random.Range(0, TextIndex.Length)];
    }
}
