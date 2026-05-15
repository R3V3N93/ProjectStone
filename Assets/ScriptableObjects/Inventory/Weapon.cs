using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "SO/Inventory")]
public class Weapon : Inventory
{
    [Header("d")] 
    public GameObject modelPrefab;
    
    [Header("Property")]
    public Inventory ammoType;
}
