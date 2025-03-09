using UnityEngine;
using UnityEngine.InputSystem;

public class InputService : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;

    private InputAction _mousePositionAction;
    private InputAction _mouseAction;

    private Vector2 _mousePosition;

    private bool _wasLeftMouseButtonPressed;
    private bool _wasLeftMouseButtonReleased;
    private bool _isLeftMouseButtonPressed;

    private void Awake()
    {
        _mousePositionAction = _playerInput.actions["MousePosition"];
        _mouseAction = _playerInput.actions["Mouse"];
    }

    private void Update()
    {
        _mousePosition = _mousePositionAction.ReadValue<Vector2>();

        _wasLeftMouseButtonPressed = _mouseAction.WasPressedThisFrame();
        _wasLeftMouseButtonReleased = _mouseAction.WasReleasedThisFrame();
        _isLeftMouseButtonPressed = _mouseAction.IsPressed();
    }

    public Vector2 GetMousePosition() => _mousePosition;
    public bool WasLeftMouseButtonPressed() => _wasLeftMouseButtonPressed;
    public bool WasLeftMouseButtonReleased() => _wasLeftMouseButtonReleased;
    public bool IsLeftMouseButtonPressed() => _isLeftMouseButtonPressed;
}
