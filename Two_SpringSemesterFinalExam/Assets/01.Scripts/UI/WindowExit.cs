using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowExit : MonoBehaviour
{
    public GameObject Target;
    public void OnClickWindowExit()
    {
        Target.SetActive(false);
    }
}
