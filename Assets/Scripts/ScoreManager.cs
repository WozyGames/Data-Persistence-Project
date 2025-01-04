using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager Instance;
    public string newPlayerName;
    public string bestScorePlayerName;
    public float BestScore;

    private void Awake()
    {

        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadPlayerData();

    }

    [System.Serializable]
    public class SaveData
    {
        public string bestScorePlayerName;
        public float BestScore;
    }

    public void SavePlayerData()
    {
        SaveData data = new SaveData();

        data.bestScorePlayerName = bestScorePlayerName;
        data.BestScore = BestScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

    }

    public void LoadPlayerData()
    {

        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {

            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestScorePlayerName = data.bestScorePlayerName;
            BestScore = data.BestScore;

        }

    }

}