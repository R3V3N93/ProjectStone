using UnityEngine;
using System;

public class TimerToDestroy : MonoBehaviour{
    [SerializeField]
    [Tooltip("Define how long will thing exist")]
    public float TimeToExist;

    private float Timer;

    public void Update() {
        Timer += Time.deltaTime;

        if (Timer >= TimeToExist) {
            Destroy(gameObject);
        }
    }
}