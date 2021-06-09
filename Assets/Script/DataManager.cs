using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class DataManager : MonoBehaviour
{
    private static DataManager _instance = null;
    public static DataManager instance { get { return _instance; } }

    public int playerHP = 3;

    public string currentScene = "Level1";

    private void Awake()
    {
        _instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        Load();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Save()
    {
        SaveData saveData = new SaveData();
        saveData.SceneName = currentScene;
        saveData.playerHP = playerHP;

        //파일 생성
        FileStream fileStream = File.Create(Application.persistentDataPath + "/save.dat");

        Debug.Log("저장 파일 생성");

        //직렬화
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        binaryFormatter.Serialize(fileStream, saveData);

        //파일 닫기
        fileStream.Close();
    }

    public void Load()
    {
        //파일이 있는지 없는지 확인
        if (File.Exists(Application.persistentDataPath + "/save.dat") == true) 
        {
            FileStream fileStream = File.Open(Application.persistentDataPath + "/save.dat", FileMode.Open);

            if (fileStream != null && fileStream.Length > 0)
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();

                SaveData saveData = (SaveData)binaryFormatter.Deserialize(fileStream);
                playerHP = saveData.playerHP;
                UIManager.instance.PlayerHP();
                currentScene = saveData.SceneName;

                fileStream.Close();
            }
        }
    }
}
