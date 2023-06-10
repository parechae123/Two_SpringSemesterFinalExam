using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JsonTester : MonoBehaviour
{
    public InventorySlot a;
    public string b;
    string filePath;
    public InventorySlot c;
    // Start is called before the first frame update
    void Start()
    {
        filePath = Path.Combine(Application.persistentDataPath, "InvenSlot.txt");
        Debug.Log(Application.persistentDataPath);
        // ���� ���� �� �ؽ�Ʈ �ۼ�
        using (StreamWriter writer = File.CreateText(filePath))//����Ƽ ����,�ý��� �� �Լ��� �������� �� ó�� �̰͵� �Լ������� using���� ������ �ٲ��ִµ�
        {
            writer.WriteLine(b = JsonUtility.ToJson(a));
        }
        if (File.Exists(filePath))
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string fileContent = reader.ReadToEnd();
                // ���� ���� ���
                Debug.Log(fileContent);
                c = JsonUtility.FromJson<InventorySlot>(fileContent);
            }
        }
        else
        {
            Debug.LogError("������ �������� �ʽ��ϴ�.");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
