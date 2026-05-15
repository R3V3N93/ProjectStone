using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "SO/Inventory")]
public class InventorySO : ScriptableObject
{
    [ToolTip("GameObject this inventory item is represented as.")]
    public GameObject gameObject;
    [ToolTip("Inventory item container GameObject")]
    public GameObject parentObject;

    [Header("Property")]
    public uint maxamount;
}
