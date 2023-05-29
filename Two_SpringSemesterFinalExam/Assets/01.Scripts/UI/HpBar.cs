using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        UIManager.Instance().HPBar = this.GetComponent<Slider>();
    }
}
