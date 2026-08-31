using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class Level : MonoBehaviour
{
    static public Level instance;
    public Player playerPrefab;
    
    public Player playerPawn { private set; get; }
    public Map currentMap { private set; get; }

    void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    
    Player SpawnPlayer(Transform where)
    {
        return Instantiate(playerPrefab, where.position, where.rotation).GetComponent<Player>();
    }
    
    public void Load(MapSO what)
    {
        Log.Debug("Game", "Loading into level  " + what.label);
        
        if(currentMap) SceneManager.UnloadSceneAsync(currentMap.data.sceneName); 
        // I always question to myself why do they not make a pointer to Scenes.
        // It's always either string or int.
        // You might think that int sounds fine, but actually the value is highly volatile.
        // So volatile that Unity sometimes changes the scene order by itself.
        // Probably I need to make a module that automatically maps Scenes to enum in runtime?
        SceneManager.LoadSceneAsync(what.sceneName, LoadSceneMode.Additive);
    }

    public void StartMap(Map from)
    {
        Game.instance.SetGameState(Game.GameStateT.Level);
        currentMap = from;

        if(from.data.DontSpawnPlayer == false)
        {
            Player spawnedPlayer = SpawnPlayer(currentMap.playerStart);
            SetPlayerPawn(spawnedPlayer);
        }
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
