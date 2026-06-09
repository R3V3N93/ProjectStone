using System;
using UnityEngine;
using UnityEngine.SceneManagement;


[Serializable]
public struct PlayerStart
{
    public Vector3 position;
    public Quaternion rotation;
};

[CreateAssetMenu(fileName = "Map", menuName = "SO/Map")]

public class MapSO : ScriptableObject
{  
    [Tooltip("Name of the map")]
    public string label;

    public string scenePath;
    
    public PlayerStart playerStart;
}
