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

    public void TestFire()
    {
        Vector3 origin = weapon.v.transform.position;
        Vector3 direction = weapon.v.transform.forward;
        LayerMask layerMask = LayerMask.GetMask("Ground", "Enemy");
        RaycastHit hitInfo;
        
        Physics.Raycast(origin, direction, hitInfo: out hitInfo, Mathf.Infinity, layerMask);
        Debug.DrawRay(origin, direction, Color.red, 0.5f, false);
        if (hitInfo.collider)
        {
            if (hitInfo.collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            {
                Debug.Log("Enemy");
                Actor a = hitInfo.transform.GetComponentInParent<Actor>();
                if (!a)
                {
                    Debug.Log("Wtf");
                    return;
                }
                
                a.TakeDamage(10);
            }
            else
            {
                Debug.Log("ground");
            }
            
        }
    }
}