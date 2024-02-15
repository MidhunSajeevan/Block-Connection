using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonEvents : MonoBehaviour
{
    private int currentLevel = 1;

    public void OnPlaybuttonClicked()
    {
        
        SceneManager.LoadScene(GameMenuStrings.AllLevel + PlayerPrefs.GetInt("LastOpenedLevel"));
    }
    public void LoadNextScene(int scene)
    {
        currentLevel = scene;
        PlayerPrefs.SetInt("LastOpenedLevel", currentLevel);
        PlayerPrefs.Save();
        SceneManager.LoadScene(GameMenuStrings.AllLevel + 1.ToString());
    }
}
