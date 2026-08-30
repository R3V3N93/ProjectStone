using System;
using QuakeLR;
using UnityEngine;

[RequireComponent(typeof(QuakeCharacterController))]
public class Falling : MonoBehaviour
{
    [Header("Controller")]
    [SerializeField]
    private QuakeCharacterController controller;
    [SerializeField]
    private float TimeToFall = 0.5f;
    [SerializeField]
    private float minFallVelocity = 15f;
    
    [Header("Land")]
    [SerializeField]
    private GameObject landingParticleSpawn;
    
    [SerializeField]
    private Transform wheretospawn;
    
    public float FallingTime {get; private set;}
    private float AirborneVelocity;
    
    private bool wasLanded = true;

    private void Awake() {
        if(controller == null){
            controller = GetComponent<QuakeCharacterController>();
        }
    }

    private void Update() {
        bool isGrounded = controller.m_OnGround;

        if (!isGrounded){
            FallingTime += Time.deltaTime;
            AirborneVelocity = controller.m_Velocity.y;
        }
        
        if(isGrounded && !wasLanded){
            PlayerLand();
        }
        
        wasLanded = isGrounded;
    }
    
    private void PlayerLand(){
        float fallSpeed = Mathf.Abs(AirborneVelocity);
        bool BigFall = FallingTime >= TimeToFall || fallSpeed >= minFallVelocity;
        
        if (BigFall){
            if (landingParticleSpawn != null) {
                Instantiate(landingParticleSpawn, wheretospawn.position, wheretospawn.rotation);
            }
        }
        
        FallingTime = 0;
    }
}
