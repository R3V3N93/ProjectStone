using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class Level : MonoBehaviour
{
    public Player playerPawn;
    static public Level instance;
    [field: SerializeField] public MapSO currentMap;

    [Header("Global Data")] 
    public GlobalSO globalSO;
    public MapListSO mapList;
    
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
                break;
        }
    }
    
    public void Load(MapSO what)
    {
        Log.Debug("Game", "Loading into level  " + what.label);
        
        Game.instance.SetGameState(Game.GameStateT.Level);
        
        if(currentMap) SceneManager.UnloadSceneAsync(currentMap.sceneName);
        
        AsyncOperation op = SceneManager.LoadSceneAsync(what.sceneName, LoadSceneMode.Additive);
        op.completed += LoadCompelete;
        
        currentMap = what;
    }

    private void LoadCompelete(AsyncOperation op)
    {
        Player spawnedPlayer = SpawnPlayer(currentMap.playerStart);
        SetPlayerPawn(spawnedPlayer);
    }
    
    public void SetPlayerPawn(Player player)
    {
        if (playerPawn != null)
        {
            playerPawn.DetachInput();
        }
        
        // Allocate new playerpawn
        playerPawn = player;
        playerPawn.AttachInput();
    }
}
