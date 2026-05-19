using UnityEngine;

[CreateAssetMenu(fileName = "InventorySO", menuName = "SO/Inventory/InventorySO")]
public class InventorySO : ScriptableObject
{
    [Tooltip("MonoBehaviour this inventory item is represented as.")]
    public Inventory monoBehaviour;
    [Tooltip("Inventory item container GameObject")]
    public GameObject parentObject;
    [Tooltip("Prefab for this Inventory")]
    public GameObject prefab;

    [Header("Property")]
    public uint maxamount;

    void Load()
    {
        if (monoBehaviour) return;
        monoBehaviour = Instantiate(prefab, parentObject.transform).GetComponent<Inventory>();

        if (!monoBehaviour)
        {
            Debug.LogError(name + " : This SO's prefab does not contain corresponding MonoBehaviour!");
        }
    }
}
