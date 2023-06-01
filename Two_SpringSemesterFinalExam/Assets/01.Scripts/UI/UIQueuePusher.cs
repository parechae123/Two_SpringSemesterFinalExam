using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIQueuePusher : MonoBehaviour
{
    private void OnEnable()
    {
        UIManager.Instance().UIStatck.Push(this.gameObject);
    }
}
