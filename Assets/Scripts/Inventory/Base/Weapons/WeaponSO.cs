using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "WeaponSO", menuName = "SO/Inventory/WeaponSO")]
public class WeaponSO : InventorySO
{
    [Header("Weapon")]
    public ViewModelWeapon viewModelPrefab; 
    public InventorySO ammoType;
    
    public override Inventory CreateInstance(Actor owner)
    {
        Weapon temp = new Weapon(this);
        temp.owner = owner; 
        return temp;
    }
}
