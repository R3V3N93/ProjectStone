using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "SO/Inventory")]
public class WeaponSO : Inventory
{
    [Header("d")] 
    public GameObject modelPrefab;

    [Header("Property")]
    public Inventory ammoType;
}
