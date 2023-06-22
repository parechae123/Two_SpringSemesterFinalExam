using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class DiaLogSystem : MonoBehaviour
{
    [SerializeField]
    private SpeakerUI[] speakers;                       //��ȭ�� �����ϴ� ĳ���͵��� UI �迭
    [SerializeField]
    private DialogData[] dialogs;                       //���� �б��� ��� ��� �迭
    public Button[] selections;
    public TextMeshProUGUI[] selectionText;
    [SerializeField]
    private bool DialogInit = true;                     //�ڵ� ���� ����
    [SerializeField]
    private bool dialogsDB = false;                     //DB�� ���� �д°� ����

    public int currentDialogIndex = -1;                 //���� ��� ����
    public int currentSpeakerIndex = 0;                 //���� ���� �ϴ� ȭ���� Speakers �迭 ����
    public float typingSpeed = 0.1f;                    //�ؽ�Ʈ Ÿ���� ȿ���� ����ӵ�
    public bool isTypingEffect = false;                 //�ؽ�Ʈ Ÿ���� ȿ���� ��������� �Ǵ�.

    public Entity_Dialogue entity_Dialogue;

    private void Awake()
    {
        SetAllClose();
        if (dialogsDB)
        {
            Array.Clear(dialogs, 0, dialogs.Length);
            Array.Resize(ref dialogs, entity_Dialogue.sheets[0].list.Count);

            int ArrayCursor = 0;
            foreach (Entity_Dialogue.Param param in entity_Dialogue.sheets[0].list)
            {
                dialogs[ArrayCursor].index = param.index;
                dialogs[ArrayCursor].speakerUIindex = param.speakerUIindex;
                dialogs[ArrayCursor].name = param.name;
                dialogs[ArrayCursor].dialogue = param.dialogue;
                dialogs[ArrayCursor].characterPath = param.characterPath;
                dialogs[ArrayCursor].tweenType = param.tweenType;
                dialogs[ArrayCursor].nextindex = param.nextindex;
                dialogs[ArrayCursor].isOnOption = param.isOnOption;
                dialogs[ArrayCursor].voicePath = param.SoundPath;
                dialogs[ArrayCursor].selectionText1 = param.selection1;
                dialogs[ArrayCursor].selectionText2 = param.selection2;
                ArrayCursor += 1;
            }
        }
    }

    //�Լ��� ���� UI�� �������ų� �Ⱥ������� ����
    private void SetActiveObjects(SpeakerUI speaker, bool visible)
    {
        speaker.imageDialog.gameObject.SetActive(visible);
        speaker.textName.gameObject.SetActive(visible);
        speaker.textDialogue.gameObject.SetActive(visible);
        //ȭ��ǥ ��簡 ����Ǿ��� ���� Ȱ��ȭ �Ǳ� ������ 
        speaker.objectArrow.SetActive(false);

        Color color = speaker.imgCharacter.color;
        if (visible)
        {
            color.a = 1;
        }
        else
        {
            color.a = 0.2f;
        }
        speaker.imgCharacter.color = color;
    }

    private void SetAllClose()
    {
        for (int i = 0; i < speakers.Length; i++)
        {
            SetActiveObjects(speakers[i], false);
        }
    }

    private void SetNextDialog(int currentIndex)
    {
        SetAllClose();
        currentDialogIndex = currentIndex;          //���� ��縦 �����ϵ���
        currentSpeakerIndex = dialogs[currentDialogIndex].speakerUIindex;       //���� ȭ�� ���� ����
        SetActiveObjects(speakers[currentSpeakerIndex], true);                  //���� ȭ���� ��ȭ ���� ������Ʈ Ȱ��ȭ
        speakers[currentSpeakerIndex].textName.text = dialogs[currentDialogIndex].name; //���� ȭ���� �̸� �ؽ�Ʈ ����
        if(dialogs[currentDialogIndex].name == "None")
        {
            speakers[currentSpeakerIndex].textName.text = "";
        }
        StartCoroutine("OnTypingText");
    }

    private IEnumerator OnTypingText()
    {
        int index = 0;
        isTypingEffect = true;

        if (dialogs[currentDialogIndex].characterPath != "None") //None�� �ƴҰ�� DB�� �־���� ����� ĳ���� �̹����� �����´�.
        {
            speakers[currentSpeakerIndex].imgCharacter.sprite =
            Resources.Load<Sprite>("CharacterIlust/"+dialogs[currentDialogIndex].characterPath);
            SoundManager.Instance().SFXInput("NPCVoice/"+dialogs[currentDialogIndex].voicePath);
            selections[0].gameObject.SetActive(false);
            selections[1].gameObject.SetActive(false);
        }
        else if (dialogs[currentDialogIndex].isOnOption)
        {
            selectionText[0].text = dialogs[currentDialogIndex].selectionText1;
            selectionText[1].text = dialogs[currentDialogIndex].selectionText2;
            selections[0].gameObject.SetActive(true);
            selections[1].gameObject.SetActive(true);
        }

        while (index < dialogs[currentDialogIndex].dialogue.Length + 1)
        {
            speakers[currentSpeakerIndex].textDialogue.text =
                dialogs[currentDialogIndex].dialogue.Substring(0, index);   //�ؽ�Ʈ�� �ѱ��ھ� Ÿ���� ��� 

            index++;
            yield return new WaitForSeconds(typingSpeed);
        }

        isTypingEffect = false;

        speakers[currentSpeakerIndex].objectArrow.SetActive(true);
    }

    public bool UpdateDialog(int currentIndex, bool InitType)
    {
        //��� �бⰡ 1ȸ�� ȣ�� 
        if (DialogInit == true && InitType == true)
        {
            SetAllClose();
            SetNextDialog(currentIndex);
            DialogInit = false;
        }
        if (Input.GetMouseButtonDown(0)&&!dialogs[currentDialogIndex].isOnOption)
        {
            Debug.Log(currentDialogIndex);
            Debug.Log(dialogs[currentDialogIndex].isOnOption);
            if (isTypingEffect == true)
            {
                isTypingEffect = false;
                StopCoroutine("OnTypingText");          //Ÿ���� ȿ���� �����ϰ� , ���� ��� ��ü�� ����Ѵ�.
                speakers[currentIndex].textDialogue.text = dialogs[currentDialogIndex].dialogue;
                //��簡 �Ϸ�Ǿ��� �� Ŀ�� 
                speakers[currentSpeakerIndex].objectArrow.SetActive(true);

                return false;
            }

            if (dialogs[currentDialogIndex].nextindex != -100)
            {
                SetNextDialog(dialogs[currentDialogIndex].nextindex);
            }
            else
            {
                SetAllClose();
                DialogInit = true;
                return true;
            }
        }
        return false;
    }
    public void fromSellectionToNextDia()
    {
        SetNextDialog(dialogs[currentDialogIndex].nextindex);
    }

    [System.Serializable]
    public struct SpeakerUI
    {
        public Image imgCharacter;          //ĳ���� �̹���
        public Image imageDialog;           //��ȭâ ImageUI
        public Text textName;               //���� ������� ĳ���� �̸� ��� TextUI
        public Text textDialogue;           //���� ��� ��� Text UI
        public GameObject objectArrow;      //��簡 �Ϸ�Ǿ��� �� ����ϴ� Ŀ�� ������Ʈ
    }

    [System.Serializable]
    public struct DialogData
    {
        public int index;                   //��� ��ȣ
        public int speakerUIindex;          //����Ŀ �迭 ��ȣ
        public string name;                 //�̸�
        public string dialogue;             //���
        public string characterPath;        //ĳ���� �̹��� ���
        public int tweenType;               //Ʈ�� ��ȣ
        public int nextindex;               //���� ��� 
        public string voicePath;
        public bool isOnOption;
        public string selectionText1;
        public string selectionText2;
    }


}