using UnityEngine;

public class Player : Actor
{
    public PlayerSO data;
    public GameObject parentWeaponRoot;
    public GameObject parentInventory;
    
    void Awake()
    {
        if(!data) Log.Error("Player", "I don't have its ScriptableObject defined. \nPossible NULL Errors!");
    }
    
    void SwitchWeapon(WeaponSO to)
    {
        
    }
}
