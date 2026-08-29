using UnityEngine;

[RequireComponent(typeof(Map))]
public class TitleMap : MonoBehaviour
{
    private Map map;
    public MenuSO menu;

    void Awake()
    {
        map = GetComponent<Map>();
    }

    void Start()
    {
        Game g = Game.instance;
        Menu m = Menu.instance;
        g.SetGameState(Game.GameStateT.MainMenu);
        m.Open(0, menu);
    }
}