using System;
using UnityEngine;

[Serializable]
public class Inventory
{
    [field: SerializeField] public InventorySO data { get; private set; }
    
    [Header("Property")]
    [field: SerializeField] public uint amount { get; private set; }

    public Inventory(InventorySO data)
    {
        this.data = data;
        Log.Debug(data.label, "Created an instance for this item");
    }

    public void Give(uint amount)
    {
        this.amount = Math.Clamp(this.amount + amount, 0, data.maxamount);
    }
    
    public void Take(uint amount)
    {
        this.amount = Math.Clamp(this.amount - amount, 0, data.maxamount);
    }
}