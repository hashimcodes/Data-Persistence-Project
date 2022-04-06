using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public string Player;
    public int Score;

    public string bestPlayerLoaded;
    public int bestScoreLoaded;

    public void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); 
    }

    [System.Serializable]
    class Data
    {
        public string bestPlayer;
        public int highscore;
    }

    public void SaveData(string BestPlayerName, int HighScore)
    {
        Data data = new Data();
        data.bestPlayer = BestPlayerName;
        data.highscore = HighScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            Data data = JsonUtility.FromJson<Data>(json);

            bestPlayerLoaded = data.bestPlayer;
            bestScoreLoaded = data.highscore;
        }
    }
}
