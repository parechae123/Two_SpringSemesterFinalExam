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
        
        
        //일단 상속을 풀었으니까 이 푼걸로 인벤토리 메니저에 저장해서 사용하는식으로 하자 인벤토리 컨트롤러에서 각 텍스트와 이미지를 스테이지마다 받아오는식

        /*filePath = Path.Combine(Application.persistentDataPath, "InvenSlot.txt");
        Debug.Log(Application.persistentDataPath);
        // 파일 생성 및 텍스트 작성
        using (StreamWriter writer = File.CreateText(filePath))//유니티 엔진,시스템 등 함수를 가져오는 것 처럼 이것도 함수내에셔 using으로 문서를 바꿔주는듯
        {
            writer.WriteLine(b = JsonUtility.ToJson(a));
        }
        if (File.Exists(filePath))
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string fileContent = reader.ReadToEnd();
                // 파일 내용 사용
                Debug.Log(fileContent);
                c = JsonUtility.FromJson<InventorySlot>(fileContent);
            }
        }
        else
        {
            Debug.LogError("파일이 존재하지 않습니다.");
        } //제이슨 저장법*/

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
