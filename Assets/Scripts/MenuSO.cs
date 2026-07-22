using UnityEngine;

[CreateAssetMenu(fileName = "MenuSO", menuName = "SO/MenuSO")]
public class MenuSO : ScriptableObject
{  
    [Tooltip("Name of the menu")]
    public string label;
    public string sceneName;
}
