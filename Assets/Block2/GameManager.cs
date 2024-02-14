using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            return;
        }
        else
        {
            Destroy(Instance);
        }
    }


    #region On ButtonCliks
    public void OnMainMenuButtonClicked()
    {
        SceneManager.LoadScene(GameMenuStrings.MainMenu);
    }

    public void OnPlayButtonClicked()
    {
        SceneManager.LoadScene(GameMenuStrings.Level_1);
    }
    public void LoadNextScene(int scene)
    {
        SceneManager.LoadScene(GameMenuStrings.AllLevel + scene.ToString());
    }
    #endregion


    //#region GAME_VARIABLES

    //[HideInInspector]
    //public int CurrentStage;

    //[HideInInspector]
    //public int CurrentLevel;

    //[HideInInspector]
    //public string StageName;

    //public bool IsLevelUnlocked(int level)
    //{
    //    string levelName = "Level" + CurrentStage.ToString() + level.ToString();

    //    if (level == 1)
    //    {
    //        PlayerPrefs.SetInt(levelName, 1);
    //        return true;
    //    }

    //    if (PlayerPrefs.HasKey(levelName))
    //    {
    //        return PlayerPrefs.GetInt(levelName) == 1;
    //    }

    //    PlayerPrefs.SetInt(levelName, 0);
    //    return false;
    //}

    //public void UnlockLevel()
    //{
    //    CurrentLevel++;

    //    if (CurrentLevel == 51)
    //    {
    //        CurrentLevel = 1;
    //        CurrentStage++;

    //        if (CurrentStage == 8)
    //        {
    //            CurrentStage = 1;
    //            OnMainMenuButtonClicked();
    //        }
    //    }

    //    string levelName = "Level" + CurrentStage.ToString() + CurrentLevel.ToString();
    //    PlayerPrefs.SetInt(levelName, 1);
    //}

    //#endregion
    //#region LEVELDATA


    //[SerializeField]
    //private LevelData DefaultLevel;
    //public LevelData GetLevel()
    //{
    //    string levelName = "Level" + CurrentStage.ToString() + CurrentLevel.ToString();

    //    if (Levels.ContainsKey(levelName))
    //    {
    //        return Levels[levelName];
    //    }

    //    return DefaultLevel;
    //}
    //#endregion

}
