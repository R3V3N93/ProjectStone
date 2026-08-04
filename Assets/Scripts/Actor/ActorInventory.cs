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

        if (what is WeaponSO && GetInventoryAmount(what) == 0)
        {
            
        }
        
        /*
        // If having none, remove from dictionary
        if (inventory[what].amount == 0)
        {
            inventory[what].Dispose
            inventory.Remove(what);
        }*/
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
}