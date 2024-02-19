using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Unity.AI.Navigation;

public class DataPersistence : MonoBehaviour
{
    public static DataPersistence Instance { get; private set; }

    public string currentName;
    public string highScoreName;
    public int highScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        LoadScore();
        Instance = this;
        DontDestroyOnLoad(gameObject);

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // returns a bool if high score was updated or not
    public bool UpdateHighScore(int newScore)
    {
        if (newScore > highScore)
        {
            highScoreName = currentName;
            highScore = newScore;
            SaveScore();
            return true;
        } else
        {
            return false;
        }
    }

    [System.Serializable]
    class SaveData
    {
        public string name;
        public int highScore;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.name = highScoreName;
        data.highScore = highScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScoreName = data.name;
            highScore = data.highScore;
        }
    }
}
