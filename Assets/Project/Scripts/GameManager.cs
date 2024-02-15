using Connect.Generator;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Connect.Core
{
    
    public class GameManager : MonoBehaviour
    {
        #region START_METHODS


        private int currentLevel = 1;

        public static GameManager Instance;

        private void Awake()
        {
            PlayerPrefs.SetInt("LastOpenedLevel", 1);
            PlayerPrefs.Save();
            if (Instance == null)
            {
                Instance = this;
                Init();
                DontDestroyOnLoad(gameObject);
                return;
            }
            else
            {
                Destroy(gameObject);
            }

        }

        private void Init()
        {
            CurrentStage = 1;
            CurrentLevel = 1;

            Levels = new Dictionary<string, LevelData>();

            foreach (var item in allLevels.Levels)
            {
                Levels[item.LevelName] = item;
            }
        }


        #endregion

        #region GAME_VARIABLES

        [HideInInspector]
        public int CurrentStage;

        [HideInInspector]
        public int CurrentLevel;

        [HideInInspector]
        public string StageName;

        public bool IsLevelUnlocked(int level)
        {
            string levelName = "Level" + CurrentStage.ToString() + level.ToString();

            if (level == 1)
            {
                PlayerPrefs.SetInt(levelName, 1);
                return true;
            }

            if (PlayerPrefs.HasKey(levelName))
            {
                return PlayerPrefs.GetInt(levelName) == 1;
            }

            PlayerPrefs.SetInt(levelName, 0);
            return false;
        }

        public void UnlockLevel()
        {
            CurrentLevel++;

            if (CurrentLevel == 51)
            {
                CurrentLevel = 1;
                CurrentStage++;

                if (CurrentStage == 8)
                {
                    CurrentStage = 1;
                    OnMainMenuButtonClicked();
                }
            }

            string levelName = "Level" + CurrentStage.ToString() + CurrentLevel.ToString();
            PlayerPrefs.SetInt(levelName, 1);
        }

        #endregion

        #region LEVEL_DATA

        [SerializeField]
        private LevelData DefaultLevel;

        [SerializeField]
        private LevelList allLevels;

        private Dictionary<string, LevelData> Levels;

        public LevelData GetLevel()
        {
            string levelName = "Level"+PlayerPrefs.GetInt("LastOpenedLevel");

            if (Levels.ContainsKey(levelName))
            {
                return Levels[levelName];
            }

            return DefaultLevel;
        }

        #endregion

        #region SCENE_LOAD

        public void GoToGameplay()
        {
             currentLevel++;
            PlayerPrefs.SetInt("LastOpenedLevel", currentLevel);
            SceneManager.LoadScene(GameMenuStrings.AllLevel + 1.ToString());
        }

        #endregion

        #region ON BUTTONCLIKS
        public void OnMainMenuButtonClicked()
        {
            SceneManager.LoadScene(GameMenuStrings.MainMenu);
        }

        public void OnPlayButtonClicked()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(GameMenuStrings.AllLevel+PlayerPrefs.GetInt("LastOpenedLevel").ToString());
        }
      
        #endregion
    }
}

