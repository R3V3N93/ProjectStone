using UnityEngine;

[CreateAssetMenu(fileName = "InventorySO", menuName = "SO/Inventory/InventorySO")]
public class InventorySO : ScriptableObject
{
    public string label = "Unknown Item";
    [Header("Property")]
    public uint maxamount;

    public virtual Inventory CreateInstance(Actor owner)
    {
        if (!owner)
        {
            Log.Error(this.name + "." + nameof(CreateInstance), "owner must NOT be null!");
        }
        Inventory temp = new Inventory(this);
        temp.owner = owner;
        return temp;
    }
}
