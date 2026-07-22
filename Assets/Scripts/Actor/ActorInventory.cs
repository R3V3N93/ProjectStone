using UnityEngine;
using System;

public class ActorInventory : MonoBehaviour
{
    [Header("Inventory")] 
    [Tooltip("Input SO to gameobject")]
    [field : SerializeField] private Dicktionary<InventorySO, Inventory> _inventory = new();
    [field : SerializeField] private Transform rootInventory;
    
    public void Give(InventorySO what, uint amount)
    {
        if (!rootInventory)
        {
            Log.Error(this.name, "I don't have inventory root defined!");
            return;
        }
        
        // Adds the inventory item to inventory root
        if(!_inventory.ContainsKey(what))
        {
            _inventory.Add(what, what.CreateInstance());
        }

        _inventory[what].Give(amount);
    }

    public void Take(InventorySO what, uint amount)
    {
        if (!_inventory.ContainsKey(what)) return;
        
        _inventory[what].Take(amount);
    }

    public uint GetInventoryAmount(InventorySO what)
    {
        if (!_inventory.ContainsKey(what)) return 0;

        return _inventory[what].amount;
    }

    public bool HasInventory(InventorySO what)
    {
        return GetInventoryAmount(what) > 0;
    }
    
    ////////////////////////////////////
    // Weapon
    ////////////////////////////////////

    [Header("Weapon")] 
    public WeaponSO currentWeapon { get; private set; }
    // This is for defining switch behaviours for each actor
    // For example, player would need to move the inventory to weapon root
    // Monsters will probably do the same but it will play unique animations
    private Action switchWeaponCompleted;
    public void SwitchWeapon(WeaponSO to)
    {
        if(!HasInventory(to))
        {
            Log.Warning(name, "Could not switch to " + to.name + ". This Actor does not have one!");
            return;
        }

        currentWeapon = to;
        
        switchWeaponCompleted?.Invoke();
    }
}