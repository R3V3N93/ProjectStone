
using UnityEngine;

[RequireComponent(typeof(WeaponObject))]
public class Shotgun : MonoBehaviour, IVWeapon, IGun
{
    [SerializeField] WeaponObject weapon;
    [SerializeField] AudioClip sndFire;
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

    public void A_SoundFire()
    {
        AudioClip[] clips = new []{sndFire};
        Sound.instance.PlaySFX(clips, this.transform);
    }
}