using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public PInputSO pinput;
    public GlobalMenuSO menus;
    void Awake()
    {
        
    }
    public void ExitToMainMenu()
    {
        string debugFuncName = nameof(Pause) + "."+nameof(ExitToMainMenu);
        
        if (!Menu.instance)
        {
            Log.Error(debugFuncName, "<color=Yellow>Menu</color> singleton is destroyed or non existent!");
            return;
        }
        
        if (!Level.instance)
        {
            Log.Error(debugFuncName, "<color=Yellow>Level</color> singleton is destroyed or non existent!");
            return;
        }
        
        Menu m = Menu.instance;

        m.Close(0);
    }

    public void ResumeGame()
    {
        string debugFuncName = nameof(Pause) + "."+nameof(ExitToMainMenu);
        
        if (!Menu.instance)
        {
            Log.Error(debugFuncName, "<color=Yellow>Menu</color> singleton is destroyed or non existent!");
            return;
        }
        
        if (!Level.instance)
        {
            Log.Error(debugFuncName, "<color=Yellow>Level</color> singleton is destroyed or non existent!");
            return;
        }
        
        Menu m =  Menu.instance;
        Level l = Level.instance;

        m.Close(0);
        l.Load(l.mapList.cgrind);
    }
}
