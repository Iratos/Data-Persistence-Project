using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class PlayersAndScores : MonoBehaviour
{
    public static PlayersAndScores Instance;
    public Text topScore1;
    
    public TMP_InputField playerName;
    public string playerTopScore;

        private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);

        
    }

    [System.Serializable]

    class SaveData
    {
        public TMP_InputField playerName;
        public string playerTopScore;
    }

    public void SavePlayer()
    {
        SaveData data = new SaveData();
        data.playerName.text = playerName.text;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadPlayer()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerName.text = data.playerName.text;
        }
    }

    public void SaveTopScore()
    {
        SaveData data = new SaveData();
        data.playerTopScore = playerTopScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadTopScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerTopScore = data.playerTopScore;
        }
    }

}
