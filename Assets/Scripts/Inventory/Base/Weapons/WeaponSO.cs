using UnityEngine;

[CreateAssetMenu(fileName = "WeaponSO", menuName = "SO/Inventory/WeaponSO")]
public class WeaponSO : InventorySO
{
    [Header("Weapon")]
    public string firstPersonScene; 
    public InventorySO ammoType;
}
