using System;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    public ActorSO data;
    
    void Awake()
    {
        if(!data) Log.Error(this.name, "I don't have its ScriptableObject defined. \nPossible NULL Errors!");
    }
    
    ////////////////////////////////////
    // MOBJ
    ////////////////////////////////////
    
    [Header("Mobj")]
    public uint health {get; set;}

    public void TakeDamage(uint damage)
    {
        health = Math.Clamp(health - damage, 0, int.MaxValue);

        if (IsDead())
            Death();
    }
    
    public bool IsDead() { return health <= 0; }

    public void Death() {}
    
    
}
