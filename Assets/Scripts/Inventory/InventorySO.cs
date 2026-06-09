using UnityEngine;

[CreateAssetMenu(fileName = "InventorySO", menuName = "SO/Inventory/InventorySO")]
public class InventorySO : ScriptableObject
{
    [Tooltip("Prefab for this Inventory")]
    public GameObject prefab;

    [Header("Property")]
    public uint maxamount;
}
