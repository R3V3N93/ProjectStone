using System;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    public ActorSO data;
    
    public ActorInventory inventory;
    public ActorWeapon weapon;
    public ActorCamera cam;
    
    void Awake()
    {
        if(!data) Log.Error(this.name, "I don't have its ScriptableObject defined. \nPossible NULL Errors!");
        
        MobjInit();
    }
    
    ////////////////////////////////////
    // MOBJ
    ////////////////////////////////////
    
    [Header("Mobj")]
    [field: SerializeField] public int health {get; private set;}
    
    public void SetHealth(int value)
    {
        health = (int)Math.Clamp(value, 0, data.maxHealth);
    }

    public void MobjInit()
    {
        SetHealth((int)data.maxHealth);
    }
    
    public void TakeDamage(int damage)
    {
        health = (int)Math.Clamp(health - damage, 0, data.maxHealth);

        if (IsDead())
            Death();
    }
    
    public bool IsDead() { return health <= 0; }

    public void Death()
    {
        Debug.Log(this.name + " is dead. Not big surprise.");
    }
}
