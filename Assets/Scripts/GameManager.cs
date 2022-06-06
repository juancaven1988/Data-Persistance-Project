using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public  class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public string player;
    public Record record;

    
 
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            
        }
        else
        {
            Destroy(gameObject);
        }
        LoadRecord();
    }

    [System.Serializable]
    class bestScore
    {
        public Record saved;
    }


    public void SaveRecord()
    {
        bestScore data = new bestScore();
        data.saved = record;
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/save.json",json);
    }

    public void LoadRecord()
    {
        string path = Application.persistentDataPath + "/save.json";

        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            bestScore data = JsonUtility.FromJson<bestScore>(json);

            GameManager.Instance.record = data.saved;
        }

    }
}

[System.Serializable]
public struct Record
{
    public string name;
    public int score;
}
