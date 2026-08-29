using UnityEngine;

public class ShotgunV : MonoBehaviour
{
    public Shotgun s;
    void Fire()
    {
        s.SoundFire();
        s.TestFire();
    }
}
