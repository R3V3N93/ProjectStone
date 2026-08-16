using System;
using UnityEngine;

[Serializable]
public struct WeaponModel
{
    public Transform transform;
    public Animator animator;
    public void Update(Transform target)
    {
        this.transform.position = target.transform.position;
        this.transform.rotation = target.transform.rotation;
    }
}

public class WeaponObject : MonoBehaviour
{
    [field:SerializeField] private Weapon inventoryDefinition;
    private bool initiated;
    [field:SerializeField] public WeaponModel v {get; private set;}
    [field:SerializeField] public WeaponModel w {get; private set;}
    
    public void Init(Weapon definition)
    {
        inventoryDefinition = definition;
        inventoryDefinition.isObjectAlive = true;

        initiated = true;
    }

    private void OnDestroy()
    {
        inventoryDefinition.isObjectAlive = false;
    }

    public void Update()
    {
        if (!initiated) return;

        w.Update(inventoryDefinition.owner.weapon.root);
        v.Update(inventoryDefinition.owner.cam.transform);
    }
}