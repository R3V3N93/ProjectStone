using System;
using UnityEngine;
using Object = System.Object;

[Serializable]
public class Inventory : Object
{
    [field: SerializeField] public InventorySO data { get; protected set; }
    [field: SerializeField] public Actor owner;
    
    [Header("Property")]
    [field: SerializeField] public uint amount { get; private set; }

    public Inventory() {}
    public Inventory(InventorySO data)
    {
        this.data = data;
        Log.Debug(data.label, "Created an instance for this item");
    }
    
    public virtual void Give(uint amount)
    {
        this.amount = Math.Clamp(this.amount + amount, 0, data.maxamount);
    }
    
    public virtual void Take(uint amount)
    {
        this.amount = Math.Clamp(this.amount - amount, 0, data.maxamount);
    }
}