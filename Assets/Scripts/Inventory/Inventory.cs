using System;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [field: SerializeField] public InventorySO data { get; private set; }
    
    [Header("Property")]
    [field: SerializeField] public uint amount { get; private set; }

    void Awake()
    {
        if(!data) Debug.LogError("This Class " + this.name + " doesn't have its ScriptableObject defined. \nPossible NULL Errors!");
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
