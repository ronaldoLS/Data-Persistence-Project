using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
#endif

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public TextMeshProUGUI highScoreAndName;

    public TMP_InputField playerNameInput;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (MainManager.Instance != null)
        {
            if (MainManager.Instance.playerName != null && MainManager.Instance.playerName != "")
                playerNameInput.text = MainManager.Instance.playerName ?? "";
            LoadNameAndBestScore();
        }


    }
    public void starGame()
    {
        if (playerNameInput.text != "")
        {
            MainManager.Instance.playerName = playerNameInput.text;
            SceneManager.LoadScene(1);
        }


    }
    public void SavePlayerName()
    {
        MainManager.Instance.SaveNameAndHighScore();
    }
    public void LoadNameAndBestScore()
    {
        // Load high score and name from MainManager singleton instance 
        MainManager.Instance.LoadNameAndHighScore();

        // Display high score and name if available 
        if (MainManager.Instance.highScoreName != "")
        {
            highScoreAndName.text = MainManager.Instance.highScoreName + " : " + MainManager.Instance.highScore;
        }

    }
    public void Exit()
    {
        SavePlayerName();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
 Application.Quit(); // original code to quit Unity player
#endif

    }
}
