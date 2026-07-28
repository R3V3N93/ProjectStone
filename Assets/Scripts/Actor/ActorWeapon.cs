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
        
        if(startIndex + 1 >= weapons.Count) return null;
        
        // I hope it's safe.
        return weapons[startIndex + 1];
    }

    public void Add(WeaponSO what)
    {
        weapons.Add(what);
    }
}

[RequireComponent(typeof(ActorInventory))]
public class ActorWeapon : MonoBehaviour
{
    private ActorInventory inventory;
    
    [field: SerializeField] public WeaponSlot[] slots = new WeaponSlot[10];
    public WeaponSO curWeapon;

    public void Awake()
    {
        inventory = GetComponent<ActorInventory>();
    }
    
    public void Unequip()
    {
        if (!curWeapon) return;
        
        curWeapon = null;
        return SceneManager.UnloadSceneAsync(curWeapon.firstPersonScene);
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
        SceneManager.LoadSceneAsync(curWeapon.firstPersonScene, LoadSceneMode.Additive);
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
        
        slots[to].Add(what);
        
    }

    public void SwitchToSlot(int to)
    {
        if(to < 0 || to >= slots.Length)
        {
            Log.Warning(this.name + "." + nameof(SwitchToSlot), "Slot is out of range. it must be within <color=Yellow>[" + 0+ "," +
                                                                (slots.Length - 1)+ "</color>");
            return;
        }

        WeaponSO toWeapon = slots[to].GetNextWeapon(curWeapon);

        if (!toWeapon) return;
        
        Equip(toWeapon);
    }
}