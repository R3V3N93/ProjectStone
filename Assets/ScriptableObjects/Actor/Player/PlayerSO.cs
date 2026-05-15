using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSO", menuName = "SO/Actor/Player/PlayerSO")]
public class PlayerSO : ScriptableObject
{
    [Header("d")]
    public GameObject parentWeaponRoot;
}
