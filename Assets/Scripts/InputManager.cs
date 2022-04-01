using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput _playerInput;
    private PlayerInput.OnFootActions _onFootActions;

    private PlayerMotor _playerMotor;
    private PlayerLook _playerLook;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _onFootActions = _playerInput.OnFoot;
        
        _playerMotor = GetComponent<PlayerMotor>();
        _playerLook = GetComponent<PlayerLook>();
        
        _onFootActions.Jump.performed += ctx => _playerMotor.Jump();

        _onFootActions.Crouch.performed += ctx => _playerMotor.Crouch();
        _onFootActions.Sprint.performed += ctx => _playerMotor.Sprint();
    }

    private void FixedUpdate()
    {
        // кажите playermotor двигаться, используя значение из нашего действия движения
        _playerMotor.ProcessMove(_onFootActions.Movement.ReadValue<Vector2>());

    }

    private void LateUpdate()
    {
        _playerLook.ProcessLook(_onFootActions.Look.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        _onFootActions.Enable();
    }

    private void OnDisable()
    {
        _onFootActions.Disable();
    }
}
