
using UnityEngine;

[RequireComponent(typeof(WeaponObject))]
public class Shotgun : MonoBehaviour, IVWeapon, IGun
{
    [SerializeField] WeaponObject weapon;
    void Awake()
    {
        weapon = GetComponent<WeaponObject>();
    }

    public void V_Fire()
    {
        weapon.v.animator.SetTrigger("Fire");
    }

    public void V_AltFire()
    {

    }
}