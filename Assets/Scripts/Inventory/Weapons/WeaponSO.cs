using UnityEngine;

[CreateAssetMenu(fileName = "WeaponSO", menuName = "SO/Inventory/WeaponSO")]
public class WeaponSO : InventorySO
{
    [Header("Property")]
    public InventorySO ammoType;
}
