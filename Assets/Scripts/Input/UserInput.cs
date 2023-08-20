using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UserInput : MonoBehaviour
{
    public static UserInput instance;

    public Vector2 MoveInput { get; private set; }
    public bool JumpJustPressed { get; private set; }
    public bool JumpBeingHeld { get; private set; }
    public bool JumpReleased { get; private set; }
    public bool AttackInput { get; private set; }
    public Vector2 LadderInput { get; private set; }

    private PlayerInput _playerInput ;

    private InputAction _moveAction;
    private InputAction _ladderAction;
    private InputAction _jumpAction;
    private InputAction _attackAction;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            _playerInput = GetComponent<PlayerInput>();
            SetInputAction();
        }
    }

    private void Update()
    {
        UpdateInput();
    }

    private void SetInputAction()
    {
        _moveAction = _playerInput.actions["Move"];
        _jumpAction = _playerInput.actions["Jump"];
        _attackAction = _playerInput.actions["Attack"];
        _ladderAction = _playerInput.actions["Ladder"];
    }

    private void UpdateInput()
    {
        MoveInput = _moveAction.ReadValue<Vector2>();
        AttackInput = _attackAction.WasPressedThisFrame();
        LadderInput = _ladderAction.ReadValue<Vector2>();
        JumpJustPressed = _jumpAction.WasPressedThisFrame();
        JumpBeingHeld = _jumpAction.IsPressed();
        JumpReleased = _jumpAction.WasReleasedThisFrame();

    }

}
