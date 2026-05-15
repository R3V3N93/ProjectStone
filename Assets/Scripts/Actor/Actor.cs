using System;
using UnityEngine;

public class Actor : MonoBehaviour
{
    public uint health {get; private set;}

    public virtual void TakeDamage(uint damage)
    {
        health = Math.Clamp(health - damage, 0, int.MaxValue);

        if (IsDead())
            Death();
    }
    
    public bool IsDead() { return health <= 0; }

    public virtual void Death() {}
}
