using System;
using UnityEngine;

[RequireComponent(typeof(ActorWeapon))]
public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private PInputSO pinput;
    [SerializeField] private Player player;
    [SerializeField] private ActorWeapon actorWeapon;

    void Awake()
    {
        actorWeapon = GetComponent<ActorWeapon>();
        player = GetComponentInParent<Player>();
        
        if (!actorWeapon)
        {
            Log.Error(this.name, "ActorWeapon doesn't exist for some fucking reason");
            return;
        }
        if (!player)
        {
            Log.Error(this.name, "Player doesn't exist for some fucking reason");
            return;
        }
        
        player.attachInputSO += AttachInput;
        player.detachInputSO += DetachInput;
    }

    void AttachInput()
    {
        pinput.weaponSlot.on += SwitchWeapon;
    }

    void DetachInput()
    {
        pinput.weaponSlot.on -= SwitchWeapon;
    }

    void SwitchWeapon()
    {
        if (actorWeapon.SwitchToSlot(pinput.lastSlot))
        {
            IVWeapon i = actorWeapon.GetCurrentWeapon().objectInstance.GetComponent<IVWeapon>();
            if (i != null)
            {
                i.AttachToPlayerInput(pinput);
            }
            
        }
    }
    
    
}