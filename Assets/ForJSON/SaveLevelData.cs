using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class SaveLevelData: MonoBehaviour
{
    public LevelData[] levelData;
    int level = 0;
        // Set this in the Inspector

    void Start()
    {
        foreach(LevelData levelData in levelData)
        {
            level++;
            // Convert LevelData to JSON string
            string json = LevelDataConverter.ConvertToJson(levelData);

            // Print or use the JSON string as needed
            File.WriteAllText(Application.dataPath + "/ForJSON/SavedLevels/Level"+level.ToString()+".json", json);
        }

    }
}
