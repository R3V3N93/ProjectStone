using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "SO/Inventory")]
public class Inventory : ScriptableObject
{
    public uint amount;
    public uint maxamount;
}
