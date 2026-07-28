using UnityEditor;
using UnityEngine;

public class WeaponDebug : EditorWindow
{
    public ActorWeapon target;
    public WeaponSO what;
    public int slot = 0;

    [MenuItem("Window/Weapon Debug")]
    public static void ShowWindow()
    {
        GetWindow<WeaponDebug>("Weapon Debug Menu");
    }

    void OnGUI()
    {
        target = EditorGUILayout.ObjectField("Target", target,  typeof(ActorWeapon), true) as ActorWeapon;
        what   = EditorGUILayout.ObjectField("What", what,  typeof(WeaponSO), true) as WeaponSO;
        slot = EditorGUILayout.IntField("Slot", slot);
        
        if (GUILayout.Button("Equip"))
        {
            if (target != null && what != null && slot >= 0)
            {
                target.Equip(what);
            }
        }
        
        if (GUILayout.Button("Add to slot"))
        {
            if (target != null && what != null && slot >= 0)
            {
                target.AddToSlot(slot, what);
            }
        }

        if (GUILayout.Button("Unequip"))
        {
            if(target != null)
                target.Unequip();
        }
    }
}