using System;
using UnityEngine;

[Serializable]
public class Weapon : Inventory
{
    public Weapon(WeaponSO what) : base(what) {}

    [field:SerializeField] public WeaponObject objectInstance { get; private set; }
    [SerializeField] public bool isObjectAlive; // null check is fucking expensive. SMH!
    
    public override void Take(uint amount)
    {
        base.Take(amount);
        
        // Take this weapon from weaponslot if no amount
        if (this.amount == 0)
        {
            owner.weapon.RemoveFromSlot(this.data as WeaponSO);
        }
    }

    public void CreateObject()
    {
        WeaponSO dat = this.data as WeaponSO;

        if (!dat)
        {
            Log.Error("Weapon." + nameof(CreateObject), "SO for this Weapon exists but is not WeaponSO!");
            return;
        }

        objectInstance = UnityEngine.Object.Instantiate(dat.prefab);
        objectInstance.Init(this);
    }

    public void DestroyObject()
    {
        if (!objectInstance) return;
        
        UnityEngine.Object.Destroy(objectInstance.gameObject);
        isObjectAlive = false;
    }
}
