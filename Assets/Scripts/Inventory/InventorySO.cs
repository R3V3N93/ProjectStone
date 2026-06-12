using UnityEngine;

[CreateAssetMenu(fileName = "InventorySO", menuName = "SO/Inventory/InventorySO")]
public class InventorySO : ScriptableObject
{
    [Tooltip("Prefab for this Inventory")]
    public Inventory prefab;

    [Header("Property")]
    public uint maxamount;

    /*void OnDestroy()
    {
        // Necessary!
        instance = null;
    }*/

    public Inventory Load(GameObject root)
    {
        if(!root)
        {
            Log.Error(name, "Could not find root! Make sure it's not null!");
            return null;
        }
        
        Inventory obj = Instantiate(prefab, root.transform);
        if (!obj)
        {
            Log.Error(name, "Could not create prefab for this inventory! Make sure it's defined or it has Inventory monoBehaviour!");
            return null;
        }

        return obj;
    }
}
