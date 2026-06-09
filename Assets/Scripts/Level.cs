using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public Player playerPawn;
    static public Level instance;
    [field: SerializeField] public MapSO currentMap;

    [Header("Global Data")] 
    public GlobalSO globalSO;
    
    void Awake()
    {
        if (instance) Destroy(gameObject);
        instance = this;
    }

    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    
    Player SpawnPlayer(PlayerStart where)
    {
        return Instantiate(Game.instance.prefabs.player, where.position, where.rotation).GetComponent<Player>();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Log.Debug("Game","Scene loaded");
        switch (Game.instance.gameState)
        {
            case Game.GameStateT.Level:
                Player spawnedPlayer = SpawnPlayer(currentMap.playerStart);
                SetPlayerPawn(spawnedPlayer);
                break;
        }
    }
    
    public void Load(MapSO what)
    {
        Log.Debug("Game", "Loading into level  " + what.label);
        
        Game.instance.SetGameState(Game.GameStateT.Level);
        SceneManager.LoadSceneAsync(what.scenePath);

        currentMap = what;
    }
    
    public void SetPlayerPawn(Player player)
    {
        PlayerMovement pm;
        if (playerPawn != null)
        {
            pm = playerPawn.GetComponent<PlayerMovement>();
            // Remove delegated methods from previous pm
            pm.DetachFromSO();
            // Detach pinputSO
            pm.pinput = null;
        }
        
        // Allocate new playerpawn
        playerPawn = player;
        pm = playerPawn.GetComponent<PlayerMovement>();
        // Attach methods to SO
        pm.pinput = globalSO.pinput;
        pm.AttachToSO();
        
    }
}
