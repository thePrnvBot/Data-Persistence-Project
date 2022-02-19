using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public string Username;
    public string CurrentPlayer;
    public int HighScore;

    public void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class SaveData
    {
        public string Username;
        public int HighScore;
    }

    public void SaveUserData(string Username, int HighScore)
    {
        SaveData data = new SaveData();
        data.HighScore = HighScore;
        data.Username = Username;

        string json = JsonUtility.ToJson(data); 

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadUserData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            SaveData data = JsonUtility.FromJson<SaveData>(json);

            HighScore = data.HighScore;
            Username = data.Username;
        }
    }
}
