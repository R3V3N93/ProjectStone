using UnityEngine;

public class Map : MonoBehaviour
{
    public MapSO data;
    
    public Transform playerStart;
    
    void Start()
    {
        RequestStartMap();
    }

    void RequestStartMap()
    {
        string debugFuncName = this.gameObject.name + nameof(RequestStartMap);
        Level l = Level.instance;
        if(!l) Log.Error(debugFuncName, "Could not find Level manager instance! Did you forget to load <color=Yellow>Main</color> scene?");

        l.StartMap(this);
    }
}