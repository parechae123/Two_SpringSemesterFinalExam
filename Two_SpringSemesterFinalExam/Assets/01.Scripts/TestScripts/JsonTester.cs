using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class dataTester
{
    public string Name;
    public int Index;
    void Testfunc()
    {

    }
}
[System.Serializable]
public class dat
{
    public List<InventorySlot> Slots = new List<InventorySlot>();
}
public class JsonTester : MonoBehaviour
{
    public InventorySlot a;
    public string b;
    string filePath;
    public InventorySlot c;
    public dat invenSlotSave;
    public dataTester dataA;
    public string dataSaver;
    public dataTester dataB;
    // Start is called before the first frame update
    void Start()
    {
        invenSlotSave.Slots.Add(new InventorySlot());
        dataA = new dataTester();
        dataA.Name = "aa";
        dataSaver = JsonUtility.ToJson(dataA);
        dataB = JsonUtility.FromJson<dataTester>(dataSaver);
        Debug.Log(dataB.Name);
        b = JsonUtility.ToJson(a);
        JsonUtility.FromJson<InventorySlot>(b);
        filePath = Path.Combine(Application.persistentDataPath, "InvenSlotTest.txt");
        Debug.Log(filePath);
        using (StreamWriter writer = File.CreateText(filePath))
        {
            writer.WriteLine(b=JsonUtility.ToJson(a));
        }
        
        
        //�ϴ� ����� Ǯ�����ϱ� �� Ǭ�ɷ� �κ��丮 �޴����� �����ؼ� ����ϴ½����� ���� �κ��丮 ��Ʈ�ѷ����� �� �ؽ�Ʈ�� �̹����� ������������ �޾ƿ��½�

        /*filePath = Path.Combine(Application.persistentDataPath, "InvenSlot.txt");
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
        } //���̽� �����*/

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
