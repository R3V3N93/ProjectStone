using System;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    public ActorSO data;
    
    void Awake()
    {
        if(!data) Log.Error(this.name, "I don't have its ScriptableObject defined. \nPossible NULL Errors!");
    }

    ////////////////////////////////////
    // Inventory
    ////////////////////////////////////
    
    [Header("Inventory")] 
    [Tooltip("Input SO to gameobject")]
    [field : SerializeField] private Dictionary<InventorySO, Inventory> _inventory = new Dictionary<InventorySO, Inventory>();
    public GameObject rootInventory;
    public void Give(InventorySO what, uint amount)
    {
        if (!rootInventory)
        {
            Log.Error(this.name, "I don't have inventory root defined!");
            return;
        }
        
        if(!_inventory.ContainsKey(what))
        {
            _inventory.Add(what, what.Load(rootInventory));
        }

        _inventory[what].Give(amount);
    }

    public void Take(InventorySO what, uint amount)
    {
        if (_inventory.ContainsKey(what) == false) return;
        
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
    // MOBJ
    ////////////////////////////////////
    
    [Header("Mobj")]
    public uint health {get; set;}

    public void TakeDamage(uint damage)
    {
        health = Math.Clamp(health - damage, 0, int.MaxValue);

        if (IsDead())
            Death();
    }
    
    public bool IsDead() { return health <= 0; }

    public void Death() {}
    
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
