using System;
using UnityEngine;

[RequireComponent(typeof(Actor))]
public class Player : MonoBehaviour
{
    [SerializeField] private Actor actor;

    void Awake()
    {
        actor = GetComponent<Actor>();
        if (!actor)
        {
            Log.Error(this.name, "Actor doesn't exist for some fucking reason");
            return;
        }
    }

    public event Action detachInputSO;
    public event Action attachInputSO;

    public void DetachInput()
    {
        detachInputSO?.Invoke();
    }
    
    public void AttachInput()
    {
        attachInputSO?.Invoke();
    }
}