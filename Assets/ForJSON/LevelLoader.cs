using UnityEngine;
using System.IO;
using System.Collections.Generic;

public class LevelLoader : MonoBehaviour
{
    public LevelSelector levelFileName;
    public List<LevelDatas> AllLevels;

    void Start()
    {
        
        foreach(var level in levelFileName.Levels)
        {
          LoadLevel(level.name);
        }
       
    }

    private void LoadLevel(string levelFileName)
    {
       
        // Read the JSON file
        string filePath = Path.Combine(Application.dataPath, "/ForJSON/SavedLevels", levelFileName);

        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            LevelDatas levelData = JsonUtility.FromJson<LevelDatas>(json);

          
            AllLevels.Add(levelData);
           
        }
        //else
        //{
        //    Debug.LogError("Level file not found: " + filePath);
        //}
      
    }
}
