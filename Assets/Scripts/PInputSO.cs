using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputEvent
{
    public event Action on;
    public event Action off;
    public bool isHeld;

    protected void InvokeOn() => on?.Invoke();
    protected void InvokeOff() => off?.Invoke();

    public virtual void Update(InputAction.CallbackContext context)
    {
        if(context.canceled)
        {
            InvokeOff();
            isHeld = false;
        }
    }
}

public class InputButton : InputEvent
{
    public override void Update(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            InvokeOn();
            isHeld = true;
        }
        base.Update(context);
    }
}

public class InputValue<T> : InputEvent
{
    public T value;
    public override void Update(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            InvokeOn();
            isHeld = true;
        }
        base.Update(context);
    }
}

[CreateAssetMenu(fileName = "PlayerInputSO", menuName = "SO/PlayerInput")]
public class PInputSO : ScriptableObject, PInput.IPlayerActions
{
    public InputButton attack = new InputButton();
    public InputButton crouch = new InputButton();
    public InputButton jump = new InputButton();
    public InputButton sprint = new InputButton();
    public InputButton weaponSlot = new InputButton();

    public int lastSlot;

    private PInput pinput;
    [field:SerializeField] public Vector2 moveDirection { get; private set; }
    [field:SerializeField] public Vector2 lookDelta { get; private set; }

    public void OnEnable()
    {
        if (pinput == null)
        {
            pinput = new PInput();
            pinput.Player.SetCallbacks(this);
        }

        pinput.Player.Enable();
    }

    public void OnDisable()
    {
        if(pinput != null) pinput.Player.Disable();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveDirection = context.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        lookDelta = context.ReadValue<Vector2>();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        attack.Update(context);
    }

    public void OnCrouch(InputAction.CallbackContext context)
    {
        crouch.Update(context);
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        jump.Update(context);
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        sprint.Update(context);
    }

    public void SwitchWeaponSlot(int slot, InputAction.CallbackContext context)
    {
        lastSlot = slot;
        weaponSlot.Update(context);
    }
    
    public void OnWeaponSlot1(InputAction.CallbackContext context)
    {
        if (context.performed) SwitchWeaponSlot(0, context);
    }

    public void OnWeaponSlot2(InputAction.CallbackContext context)
    {
        if (context.performed) SwitchWeaponSlot(1, context);
    }

    public void OnWeaponSlot3(InputAction.CallbackContext context)
    {
        if (context.performed) SwitchWeaponSlot(2, context);
    }

    public void OnWeaponSlot4(InputAction.CallbackContext context)
    {
        if (context.performed) SwitchWeaponSlot(3, context);
    }

    public void OnWeaponSlot5(InputAction.CallbackContext context)
    {
        if (context.performed) SwitchWeaponSlot(4, context);
    }
}

