using UnityEngine;
using System.Collections.Generic;

public class LevelDataConverter : MonoBehaviour
{
    // Convert LevelData to JSON string
    public static string ConvertToJson(LevelData levelData)
    {
        return JsonUtility.ToJson(levelData, true);
    }
}
