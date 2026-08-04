using UnityEngine;

public class ViewModelElement : MonoBehaviour
{
    public Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }
}
