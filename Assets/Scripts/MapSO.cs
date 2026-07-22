using System;
using UnityEngine;


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

    public string sceneName;
    
    public PlayerStart playerStart;
}
