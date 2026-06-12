using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "LoadList", menuName = "SO/LoadList")]
public class LoadListSO : ScriptableObject
{
    public List<InventorySO> inventory;
}
