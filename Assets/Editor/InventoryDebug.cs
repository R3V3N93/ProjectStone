using UnityEditor;
using UnityEngine;

public class InventoryDebug : EditorWindow
{

    public ActorInventory target;
    public InventorySO what;
    public int amount = 0;

    [MenuItem("Window/Inventory Debug")]
    public static void ShowWindow()
    {
        GetWindow<InventoryDebug>("Inventory Debug Menu");
    }

    void OnGUI()
    {
        target = EditorGUILayout.ObjectField("Target", target,  typeof(ActorInventory), true) as ActorInventory;
        what   = EditorGUILayout.ObjectField("What", what,  typeof(InventorySO), true) as InventorySO;
        amount = EditorGUILayout.IntField("Amount", amount);
        
        if (GUILayout.Button("Give"))
        {
            if (target != null && what != null && amount > 0)
            {
                target.Give(what, (uint)amount);
            }
        }
        
        if (GUILayout.Button("Take"))
        {
            if (target != null && what != null && amount > 0)
            {
                target.Take(what, (uint)amount);
            }
        }
    }
}