using UnityEngine;

public class Level : MonoBehaviour
{
    static public Level instance;
    public GameObject playerStart;
    void Awake()
    {
        if (instance) Destroy(gameObject);
        instance = this;
    }

    GameObject SpawnPlayer()
    {
        return Instantiate(Game.instance.prefabs.player, this.transform);
    }
}
