using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LandInputsubscription : MonoBehaviour
{
    public Vector2 moveInput { get; private set; } = Vector2.zero;
    public bool JumpInput { get; private set; } = false;

    public bool EscapeInput { get; private set; } = false;

    public bool MapInput { get; private set; } = false;

    public bool InventoryInput { get; private set; } = false;

    public bool InteractionInput { get; private set; } = false;

    public bool DashInput { get; private set; } = false;

    public float LclickInput { get; private set; } = 0;

    public float RclickInput { get; private set; } = 0;


    PlayerControls _Input = null;
    private void Awake()
    {
        if (_Input == null)
        {
            _Input = new PlayerControls();
        }
    }

    private void OnEnable()
    {
        SubscribeActions();
    }
    private void OnDisable()
    {
        UnsubscribeActions();
    }

    #region 폴링
    void SetMovement(InputAction.CallbackContext ctx)
    {
        moveInput = ctx.ReadValue<Vector2>();

    }

    void SetJump(InputAction.CallbackContext ctx)
    {
        JumpInput = ctx.started;
    }
    void SetEscpe(InputAction.CallbackContext ctx)
    {
        EscapeInput = ctx.started;
    }
    void SetMap(InputAction.CallbackContext ctx)
    {
        MapInput = ctx.started;
    }
    void SetInventory(InputAction.CallbackContext ctx)
    {
        InventoryInput = ctx.started;
    }
    void SetInteraction(InputAction.CallbackContext ctx)
    {
        InteractionInput = ctx.started;
    }
    void SetDash(InputAction.CallbackContext ctx)
    {
        DashInput = ctx.started;
    }

    void SetLeftClick(InputAction.CallbackContext ctx)
    {
        LclickInput = ctx.ReadValue<float>();
    }
    void SetRightClick(InputAction.CallbackContext ctx)
    {
        RclickInput = ctx.ReadValue<float>();
    }
    #endregion
    #region 이벤트구독
    private void SubscribeActions()
    {
        _Input.Player.Enable();
        _Input.Player.MovementInput.performed += SetMovement;
        _Input.Player.MovementInput.canceled += SetMovement;

        _Input.Player.JumpInput.started += SetJump;
        _Input.Player.JumpInput.canceled += SetJump;

        _Input.Player.EscapeInput.started += SetEscpe;
        _Input.Player.EscapeInput.canceled += SetEscpe;

        _Input.Player.MapInput.started += SetMap;
        _Input.Player.MapInput.canceled += SetMap;

        _Input.Player.InventoryInput.started += SetInventory;
        _Input.Player.InventoryInput.canceled += SetInventory;

        _Input.Player.InteractionInput.started += SetInteraction;
        _Input.Player.InteractionInput.canceled += SetInteraction;

        _Input.Player.DashInput.started += SetDash;
        _Input.Player.DashInput.canceled += SetDash;

        _Input.Player.BasicAttackInput.started += SetLeftClick;
        _Input.Player.BasicAttackInput.canceled += SetLeftClick;

        _Input.Player.SpecialAttackInput.started += SetRightClick;
        _Input.Player.SpecialAttackInput.canceled += SetRightClick;


    }
    private void UnsubscribeActions()
    {

        _Input.Player.MovementInput.performed -= SetMovement;
        _Input.Player.MovementInput.canceled -= SetMovement;

        _Input.Player.JumpInput.started -= SetJump;
        _Input.Player.JumpInput.canceled -= SetJump;

        _Input.Player.EscapeInput.started -= SetEscpe;
        _Input.Player.EscapeInput.canceled -= SetEscpe;

        _Input.Player.MapInput.started -= SetMap;
        _Input.Player.MapInput.canceled -= SetMap;

        _Input.Player.InventoryInput.started -= SetInventory;
        _Input.Player.InventoryInput.canceled -= SetInventory;

        _Input.Player.InteractionInput.started -= SetInteraction;
        _Input.Player.InteractionInput.canceled -= SetInteraction;

        _Input.Player.DashInput.started -= SetDash;
        _Input.Player.DashInput.canceled -= SetDash;

        _Input.Player.BasicAttackInput.started -= SetLeftClick;
        _Input.Player.BasicAttackInput.canceled -= SetLeftClick;

        _Input.Player.SpecialAttackInput.started -= SetRightClick;
        _Input.Player.SpecialAttackInput.canceled -= SetRightClick;

        _Input.Player.Disable();
    }
    #endregion
}
