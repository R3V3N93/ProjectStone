using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Map", menuName = "SO/Map")]

public class MapSO : ScriptableObject
{  
    [Tooltip("Name of the map")]
    public string label;
    public string sceneName;

    [Header("Flags")]
    public bool DontSpawnPlayer = false;
}
