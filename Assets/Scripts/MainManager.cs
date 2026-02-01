using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    public string highScoreName = "";
    public int highScore = 0;

    public string playerName = "";



    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        
        
        //SaveNameAndHighScore();
        LoadNameAndHighScore();
    }

    [System.Serializable]
    class SaveData
    {
        public string HighScoreName;
        public int HighScore;
    }

    public void SaveNameAndHighScore()
    {

        SaveData data = new SaveData();
        data.HighScoreName = highScoreName;
        data.HighScore = highScore;
        string json = JsonUtility.ToJson(data);
        System.IO.File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadNameAndHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (System.IO.File.Exists(path))
        {
            string json = System.IO.File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            highScoreName = data.HighScoreName;
            highScore = data.HighScore;
        }
    }
}
