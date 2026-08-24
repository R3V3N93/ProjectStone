using UnityEngine;
using QuakeLR;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(QuakeCharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public PInputSO pinput;

    private Player player;
    private QuakeCharacterController controller;
    
    public Transform playerCamera;
    private float playerCameraPitch = 0f;
    public Vector2 lookSpeed = new Vector2(0.5f, 0.5f);

    void Awake()
    {
        controller = GetComponent<QuakeCharacterController>();
        player = GetComponentInParent<Player>();

        player.attachInputSO += SubscribeInput;
        player.detachInputSO += UnsubscribeInput;
    }

    public void SubscribeInput()
    {
        pinput.jump.on += controller.TryJump;
    }

    public void UnsubscribeInput()
    {
        pinput.jump.on -= controller.TryJump;
    }

    void OnEnable() => SubscribeInput();
    void OnDisable() => UnsubscribeInput();

    void Update()
    {
        controller.ControllerThink(Time.deltaTime);
        Move();
        Look();
    }

    void Look()
    {
        // X
        player.transform.Rotate(Vector3.up * (pinput.lookDelta.value.x * lookSpeed.x));

        // Y
        playerCameraPitch -= pinput.lookDelta.value.y * lookSpeed.y;
        playerCameraPitch = Mathf.Clamp(playerCameraPitch, -80.0f, 90.0f);

        playerCamera.localRotation =
            Quaternion.Euler(playerCameraPitch, 0f, 0f);
    }

    void Move()
    {
        Vector3 moveDirection = (playerCamera.forward * pinput.moveDir.value.y + playerCamera.right * pinput.moveDir.value.x);
        controller.Move(moveDirection);
    }
}