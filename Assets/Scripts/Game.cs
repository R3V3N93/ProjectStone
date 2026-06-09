using System;
using UnityEngine;

public class Game : MonoBehaviour
{
    static public Game instance;
    public GlobalPrefabSO prefabs;
    [field:SerializeField] public Player playerPawn {get; private set;}

    public enum GameStateT
    {
        MainMenu,
        Level,
        Pause
    };

    [field: SerializeField] public GameStateT gameState {get; private set;}
    
    void Awake()
    {
        if (instance) Destroy(gameObject);

        SetGameState(GameStateT.MainMenu);
        instance = this;
    }
    
    private void Start()
    {
    }

    public void SetGameState(GameStateT to)
    {
        Log.Debug("Game", "gameState is set to <color=yellow>" + to + "</color>");
        this.gameState = to;

        switch (to)
        {
            case GameStateT.Level:
                Cursor.visible = false;
                break;
            case GameStateT.Pause:
                Cursor.visible = true;
                break;
            case GameStateT.MainMenu:
                Cursor.visible = true;
                break;
        }
    }
}
