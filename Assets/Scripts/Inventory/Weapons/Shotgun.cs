
using UnityEngine;

[RequireComponent(typeof(WeaponObject))]
public class Shotgun : MonoBehaviour, IViewModelWeapon, IGun
{
    [SerializeField] WeaponObject weapon;
    void Awake()
    {
        weapon = GetComponent<WeaponObject>();
    }

    void V_Fire()
    {
        weapon.vAnim.SetTrigger("Fire");
    }

    void V_AltFire()
    {

    }
}