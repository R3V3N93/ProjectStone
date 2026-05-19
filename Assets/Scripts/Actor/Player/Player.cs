using UnityEngine;

public class Player : Actor
{
    public PlayerSO data;
    public GameObject parentWeaponRoot;
    public GameObject parentInventory;
    
    void Awake()
    {
        if(!data) Debug.LogError("This Class " + this.name + " doesn't have its ScriptableObject defined. \nPossible NULL Errors!");
    }
    
    void SwitchWeapon(WeaponSO to)
    {
        
    }
}
