public class Weapon : Inventory
{
    public Weapon(WeaponSO what) : base(what) {}
    public int curSlot = -1;
    
    public void Fire() {}
    public void AltFire() {}
}
