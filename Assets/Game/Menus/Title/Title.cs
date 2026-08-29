using UnityEngine;

public class Title : MonoBehaviour
{
    public MapSO hub;
    public void StartGame()
    {
        string debugFuncName = nameof(Title) + "."+nameof(StartGame);
        
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
        l.Load(hub);
    }
}