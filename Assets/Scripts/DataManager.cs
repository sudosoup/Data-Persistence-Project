using UnityEditor.Overlays;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{

    public static DataManager Instance;
    public string PlayerName;
    public string PlayerHighScoreName;
    public int HighScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log(Application.persistentDataPath);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    class SaveData
    {
        public string Player;
        public int Score;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.Score = HighScore;
        data.Player = PlayerName;

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

            PlayerHighScoreName = data.Player;
            HighScore = data.Score;
        }

    }
}
