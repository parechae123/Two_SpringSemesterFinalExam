using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXPTester : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnEXPTester()
    {
        UIManager.Instance().GetEXP( 10);
    }
}
