using System;
using UnityEngine;

public class Game : MonoBehaviour
{
    static public Game instance;
    public GlobalPrefabSO prefabs;
    [field:SerializeField] public Player playerPawn {get; private set;}
    void Awake()
    {
        if (instance) Destroy(gameObject);

        instance = this;
    }
    
    private void Start()
    {
        Cursor.visible = false;
    }
    
    public void SetPlayerPawn(Player player)
    {
        PlayerMovement pm = playerPawn.GetComponent<PlayerMovement>();
        // Remove delegated methods from previous pm
        pm.DetachFromSO();
        PlayerInputSO so = pm.pinput;
        // Detach pinputSO
        pm.pinput = null;
        
        // Allocate new playerpawn
        playerPawn = player;
        pm = playerPawn.GetComponent<PlayerMovement>();
        // Attach methods to SO
        pm.pinput = so;
        pm.AttachToSO();
        
    }
}
