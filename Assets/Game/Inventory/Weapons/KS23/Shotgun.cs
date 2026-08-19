
using UnityEngine;

[RequireComponent(typeof(WeaponObject))]
public class Shotgun : MonoBehaviour, IPlayerWeapon, IGun
{
    private WeaponObject weapon;
    [SerializeField] AudioClip sndFire;
    void Awake()
    {
        weapon = GetComponent<WeaponObject>();
    }

    public void Fire()
    {
        weapon.w.animator.SetTrigger("Fire");
    }

    public void V_Fire()
    {
        weapon.v.animator.SetTrigger("Fire");
    }

    public void V_AltFire()
    {

    }

    public void SoundFire()
    {
        AudioClip[] clips = new []{sndFire};
        Sound.instance.PlaySFX(clips, this.transform);
    }
}