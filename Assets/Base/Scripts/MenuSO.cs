using UnityEngine;

[CreateAssetMenu(fileName = "Menu", menuName = "SO/Menu")]
public class MenuSO : ScriptableObject
{  
    [Tooltip("Name of the menu")]
    public string label;
    public string sceneName;
}
