using System;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [field: SerializeField] public InventorySO data { get; private set; }
    static public Inventory instance { get; private set; }
    
    [Header("Property")]
    [field: SerializeField] public uint amount { get; private set; }

    void Awake()
    {
        if (instance) Destroy(gameObject);

        instance = this;
        
        if(!data) Debug.LogError("This Class " + this.name + " doesn't have its ScriptableObject defined. \nPossible NULL Errors!");
    }
    
    static void Give(uint amount)
    {
        if (!instance) return;
        instance.amount = Math.Clamp(amount + instance.amount, 0, instance.data.maxamount);
    }
    
    static void Take(uint amount)
    {
        if (!instance) return;
        instance.amount = Math.Clamp(amount + instance.amount, 0, instance.data.maxamount);
    }
}
