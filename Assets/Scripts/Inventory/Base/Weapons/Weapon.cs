using UnityEngine;

public class Weapon : Inventory
{
    public Weapon(WeaponSO what) : base(what) {}
    
    [SerializeField] private ViewModelWeapon viewModel;
    //[SerializeField] private ViewModelWeapon worldModel;
    
    public override void Take(uint amount)
    {
        base.Take(amount);
        
        // Take this weapon from weaponslot if no amount
        if (this.amount == 0)
        {
            owner.weapon.RemoveFromSlot(this.data as WeaponSO);
        }
    }
}
