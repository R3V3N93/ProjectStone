using UnityEngine;
using System;

public class ActorInventory : MonoBehaviour
{
    [Header("Inventory")] 
    [Tooltip("Input SO to gameobject")]
    [field : SerializeField] private Dicktionary<InventorySO, Inventory> inventory = new();
     
    public void Give(InventorySO what, uint amount)
    {
        // Adds the inventory item to inventory root
        if(!inventory.ContainsKey(what))
        {
            inventory.Add(what, what.CreateInstance());
        }

        inventory[what].Give(amount);
        
        Log.Debug(this.name + "." + nameof(Give), "Gave Item <color=Yellow>" + what.label + "</color> with amount of <color=Yellow>" + amount + "</color>\nCurrent Amount : <color=Yellow>" + GetInventoryAmount(what) + "</color>");
    }

    public void Take(InventorySO what, uint amount)
    {
        if (!inventory.ContainsKey(what)) return;
        
        inventory[what].Take(amount);
        
        Log.Debug(this.name + "." + nameof(Take), "Took Item <color=Yellow>" + what.label + "</color> with amount of <color=Yellow>" + amount + "</color>\nCurrent Amount : <color=Yellow>" + GetInventoryAmount(what) + "</color>");
    }

    public uint GetInventoryAmount(InventorySO what)
    {
        if (!inventory.ContainsKey(what)) return 0;

        return inventory[what].amount;
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