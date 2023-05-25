using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DiaLogSystemParent : MonoBehaviour
{
    public TextMeshProUGUI targetText;
    // Start is called before the first frame update
    protected IEnumerator TextTypingAct(int TextL, string Name, string Dialog)
    {
        targetText.text = "";
        if (TextL == 0)
        {
            StopCoroutine(TextTypingAct(0, Name, Dialog));
        }
        else
        {
            for (int i = 0; i <= TextL; i++)
            {
                yield return new WaitForSecondsRealtime(Random.Range(0.03f,0.07f));
                targetText.text = Name + "\n" + Dialog.Substring(0, i);
            }
        }
    }
}
