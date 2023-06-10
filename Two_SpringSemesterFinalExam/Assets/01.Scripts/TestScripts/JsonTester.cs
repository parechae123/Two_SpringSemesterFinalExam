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
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
