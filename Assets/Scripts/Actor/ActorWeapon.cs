using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

[Serializable]
public class WeaponSlot
{
    [field : SerializeField] private List<WeaponSO> weapons = new List<WeaponSO>();

    public WeaponSO GetNextWeapon(WeaponSO from = null)
    {
        // No weapon, return nothing
        if(weapons.Count == 0) return null;
        
        // Starts from -1 since it will be incremented later.
        // In turn making sure it starts from zero
        int startIndex = -1;
        if (from != null)
        {
            startIndex = weapons.LastIndexOf(from);
        }
        
        if(startIndex + 1 >= weapons.Count) startIndex = -1;
        
        // I hope it's safe.
        return weapons[startIndex + 1];
    }

    public bool Add(WeaponSO what)
    {
        if (!what) return false;
        if(weapons.Contains(what)) return false;
        
        weapons.Add(what);
        return true;
    }

    public bool Remove(WeaponSO what)
    {
        if (!what) return false;
        if(!weapons.Contains(what)) return false;
        
        weapons.Remove(what);
        return true;
    }

    public bool Find(WeaponSO what)
    {
        return weapons.Contains(what);
    }
}

[RequireComponent(typeof(ActorInventory))]
public class ActorWeapon : MonoBehaviour
{
    [field: SerializeField] public Transform root;
    private ActorInventory inventory;
    
    [field: SerializeField] public WeaponSlot[] slots = new WeaponSlot[10];
    public WeaponSO curWeapon;

    public void Awake()
    {
        inventory = GetComponent<ActorInventory>();
        inventory.actor.weapon = this;
    }
    
    public void Unequip()
    {
        if (!curWeapon) return;
        
        
        GetCurrentWeapon().DestroyObject();
        curWeapon = null;
    }
    
    public void Equip(WeaponSO what, bool ignoreCheckPossession = false)
    {
        if (!inventory.HasInventory(what) && !ignoreCheckPossession)
        {
            Log.Warning(this.name + "." + nameof(Equip), "Could not equip weapon <color=Yellow>" + what.label + "</color> because it's not present in inventory!");
            return;
        }
            
        Unequip();
        
        curWeapon = what;
        GetCurrentWeapon().CreateObject();
        
    }
    
    // TODO : Find a way to unify these error messages! Mayhaps through error code method. Copy pasting them every time is retarded
    public void AddToSlot(int to, WeaponSO what)
    {
        string debugFuncName = this.name + "." + nameof(AddToSlot);
        if(to < 0 || to >= slots.Length)
        {
            Log.Warning(debugFuncName, "Slot is out of range. it must be within <color=Yellow>[" + 0+ "," +
                                       (slots.Length - 1)+ "</color>");
            return;
        }
        
        if(!what)
        {
            Log.Warning(debugFuncName, "Given weapon is null!");
            return;
        }
        
        if(!inventory.HasInventory(what))
        {
            Log.Warning(debugFuncName, "Given weapon <color=Yellow>"+what.label+"</color> is not present in inventory!");
            return;
        }
        
        if(slots[to].Add(what))
            Log.Debug(debugFuncName, "Added weapon <color=Yellow>" + what.label + "</color> to <color=Yellow>Slot " + to + "</color>");
        else
            Log.Warning(debugFuncName, "Failed to add weapon <color=Yellow>" + what.label + "</color> to <color=Yellow>Slot " + to + "</color>");
    }

    public void RemoveFromSlot(WeaponSO what)
    {
        string debugFuncName = this.name + "." + nameof(RemoveFromSlot);
        
        if(!what)
        {
            Log.Warning(debugFuncName, "Given weapon is null!");
            return;
        }

        WeaponSlot from = null;
        foreach (WeaponSlot slot in slots)
        {
            if (slot.Find(what))
            {
                from = slot;
                break;
            }
        }

        if (from == null)
        {
            return;
        }
        
        if(from.Remove(what))
            Log.Debug(debugFuncName, "Removed weapon <color=Yellow>" + what.label + "</color> from <color=Yellow>Slot " + from + "</color>");
        else
            Log.Warning(debugFuncName, "Failed to remove weapon <color=Yellow>" + what.label + "</color> from <color=Yellow>Slot " + from + "</color>");
    }
    
    public bool SwitchToSlot(int to)
    {
        if(to < 0 || to >= slots.Length)
        {
            Log.Warning(this.name + "." + nameof(SwitchToSlot), "Slot is out of range. it must be within <color=Yellow>[" + 0+ "," +
                                                                (slots.Length - 1)+ "</color>");
            return false;
        }

        WeaponSO toWeapon = slots[to].GetNextWeapon(curWeapon);

        if (!toWeapon) return false;
        
        Equip(toWeapon);
        return true;
    }

    public Weapon GetCurrentWeapon()
    {
        if (!curWeapon) return null;
        return inventory.GetInventory(curWeapon) as Weapon;
    }
}