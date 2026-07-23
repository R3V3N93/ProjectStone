using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public static Menu instance;

    public MenuSO[] layers = new MenuSO[10];
    
    void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    public void Close(int layer)
    {
        string debugFuncName = this.name + "." + nameof(Close);

        if (layer < 0 || layer >= layers.Length)
        {
            Log.Error(debugFuncName, "Given layer <color=yellow>" + layer + "</color> is out of bound! Legal layer is <color=yellow>[0,"+ (layers.Length - 1)+"]</color>");
            return;
        }
        
        MenuSO curMenu = layers[layer];
        if (!curMenu) return;
        
        Log.Debug(debugFuncName, "Closed menu <color=yellow>" + curMenu.label + "</color> on layer <color=yellow>" + layer + "</color>");
        
        SceneManager.UnloadSceneAsync(curMenu.sceneName);
        
        layers[layer] = null;
    }
    
    public void Open(int layer, MenuSO what)
    {
        string debugFuncName = this.name + "." + nameof(Open);
        
        if (layer < 0 || layer >= layers.Length)
        {
            Log.Error(debugFuncName, "Given layer <color=yellow>" + layer + "</color> is out of bound! Legal layer is <color=yellow>[0,"+ (layers.Length - 1)+"]</color>");
            return;
        }
        
        if (!what)
        {
            Log.Error(debugFuncName, "Could not open menu! Given menu is null");
            return;
        }

        if (layers[layer])
            Close(layer);
        
        SceneManager.LoadSceneAsync(what.sceneName, LoadSceneMode.Additive);
        
        layers[layer] = what;
        
        Log.Debug(debugFuncName, "Opened menu <color=yellow>" + what.label + "</color> on layer <color=yellow>" + layer + "</color>");
    }
}
