using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputRouter : IControl
{
    private readonly CharacterInput _input = new();

    public event Action<Vector2> onUp;
    public event Action<Vector2> onMove;

    private Vector2 _endPosition;

    private bool _isActive = false;
    private bool _isEnable = false;

    public void SetActive(bool value)
    => _isActive = value;

    private void OnDrag(InputAction.CallbackContext obj)
    {
        if (_isActive == false)
            return;

        _endPosition = obj.ReadValue<Vector2>();
        onMove.Invoke(_endPosition);
    }

    private void OnPointerUp(InputAction.CallbackContext obj)
    {
        if (_isActive == false)
            return;

        onUp.Invoke(_endPosition);
    }

    public void OnEnable()
    {
        if (_isEnable)
            return;

        _input.Enable();

        _input.Character.Drag.performed += OnDrag;
        _input.Character.TouchPress.canceled += OnPointerUp;

        _isEnable = true;
    }

    public void OnDisable()
    {
        if (_isEnable == false)
            return;

        _input.Disable();
        _input.Dispose();

        _input.Character.Drag.performed -= OnDrag;
        _input.Character.TouchPress.canceled -= OnPointerUp;

        _isEnable = false;
    }
}
