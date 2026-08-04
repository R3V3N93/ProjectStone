using UnityEngine;

public class ViewModel : MonoBehaviour
{
    public static ViewModel instance;
    [SerializeField] private ViewModelElement curElement;

    public ViewModelElement GetElement()
    {
        return curElement;
    }
    
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }

    public void Load(ViewModelElement prefab)
    {
        curElement = Instantiate(prefab, this.transform);
    }

    public void Unload()
    {
        if (curElement == null) return;
        Destroy(curElement.gameObject);
        curElement = null;
    }
}