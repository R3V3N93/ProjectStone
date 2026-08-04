using UnityEngine;

[CreateAssetMenu(fileName = "InventorySO", menuName = "SO/Inventory/InventorySO")]
public class InventorySO : ScriptableObject
{
    public string label = "Unknown Item";
    [Header("Property")]
    public uint maxamount;

    public virtual Inventory CreateInstance()
    {
        Inventory temp = new Inventory(this);
        return temp;
    }
}
