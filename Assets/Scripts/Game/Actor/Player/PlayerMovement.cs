using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public PInputSO pinput;

    [SerializeField] private Player player;
    [SerializeField] private CharacterController controller;
    
    public GameObject playerCamera;
    private float playerCameraPitch = 0f;

    [Header("Properties")] 
    [Header("Body")]
    [SerializeField] private bool grounded;
    [Tooltip("Used for rough grounds to give visual perfection(e.g. cobbles etc)")]
    public float groundedOffset;

    public LayerMask groundLayer;
    [Header("Movement")] 
    public float gravity = -9.81f;
    public float terminalVelocity = 53f;
    public float verticalVelocity;
    
    public float speedChangeRate = 1f;
    public float speedMove = 1f;
    public float speedJump = 2f;
    public Vector2 speedLook = new Vector2(0.5f, 0.5f);
    

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        player = GetComponentInParent<Player>();
        
        if (!player)
        {
            Log.Error(this.name, "Player doesn't exist for some fucking reason");
            return;
        }

        player.attachInputSO += AttachInput;
        player.detachInputSO += DetachInput;
    }

    public void AttachInput()
    {
        pinput.eventJump += JumpEvent;
    }

    public void DetachInput()
    {
        pinput.eventJump -= JumpEvent;
    }

    void JumpEvent()
    {
        Jump();
    }
    
    void Update()
    {
        if (!pinput) return;
        GroundedCheck();
        Gravity();
        CameraRotation();
        Movement();
    }
    
    private void GroundedCheck()
    {
        Vector3 spherePosition = new Vector3(transform.position.x, transform.position.y - groundedOffset, transform.position.z);
        grounded = Physics.CheckSphere(spherePosition, controller.radius, groundLayer, QueryTriggerInteraction.Ignore);
    }
    
    void Gravity()
    {
        if (grounded)
        {
            if (verticalVelocity < 0f)
            {
                verticalVelocity = 0f;
            }
        }
        else
        {
            if (Mathf.Abs(verticalVelocity) < terminalVelocity)
            {
                verticalVelocity += gravity * Time.deltaTime;
            }
        }
        
    }

    void Jump()
    {
        if (grounded)
        {
            verticalVelocity = speedJump;
        }
    }

    void CameraRotation()
    {
        if (pinput.lookDelta.sqrMagnitude > 0)
        {
            player.transform.Rotate(Vector3.up * (pinput.lookDelta.x * speedLook.x));
            playerCameraPitch -= pinput.lookDelta.y * speedLook.y;
            playerCameraPitch = Mathf.Clamp(playerCameraPitch, -80.0f, 90.0f);
            playerCamera.transform.localRotation =
                Quaternion.Euler(playerCameraPitch, 0f, 0f);
        }
    }

    void Movement()
    {
        Vector3 inputDirection = new Vector3(pinput.moveDirection.x, 0.0f, pinput.moveDirection.y).normalized;

        float calculatedSpeed = 0f;
        float targetSpeed = speedMove;
        if (pinput.moveDirection == Vector2.zero) targetSpeed = 0.0f;
        
        float currentHorizontalSpeed = new Vector3(controller.velocity.x, 0.0f, controller.velocity.z).magnitude;

        float speedOffset = 0.1f;
        
        if (currentHorizontalSpeed < targetSpeed - speedOffset || currentHorizontalSpeed > targetSpeed + speedOffset)
        {
            calculatedSpeed = Mathf.Lerp(currentHorizontalSpeed, targetSpeed, Time.deltaTime * speedChangeRate);
            calculatedSpeed = Mathf.Round(calculatedSpeed * 1000f) / 1000f;
        }
        else
        {
            calculatedSpeed = targetSpeed;
        }
        
        if (pinput.moveDirection != Vector2.zero)
        {
            inputDirection = transform.right * pinput.moveDirection.x + transform.forward * pinput.moveDirection.y;
        }
        
        controller.Move(inputDirection * (Time.deltaTime * calculatedSpeed) + new Vector3(0.0f, verticalVelocity, 0.0f) * Time.deltaTime);
    }
}