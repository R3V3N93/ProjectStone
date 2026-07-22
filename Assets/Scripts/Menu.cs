using UnityEngine;

public class Menu : MonoBehaviour
{
    public static Menu instance;

    void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    public static void OpenMenu(string name)
    {
        
    }
}
