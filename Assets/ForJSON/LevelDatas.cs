using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class LevelDatas : ScriptableObject
{
    public string LevelName;
    public List<Edgepoints> Edges;
}

[Serializable]
public struct Edgepoints
{
    public List<Vector2Int> Points;

    public Vector2Int StartPoint
    {
        get
        {
            if (Points != null && Points.Count > 0)
            {
                return Points[0];
            }
            return new Vector2Int(-1, -1);
        }
       
    }

    public Vector2Int EndPoint
    {
        get
        {
            if (Points != null && Points.Count > 0)
            {
                return Points[Points.Count - 1];
            }
            return new Vector2Int(-1, -1);
        }
    }
}
