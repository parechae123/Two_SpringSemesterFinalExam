using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statbuttons : MonoBehaviour
{
    public void OnStatButtonClick()
    {
        GameManager.GMinstance().PlrStatusChange(transform.name);
    }
}
