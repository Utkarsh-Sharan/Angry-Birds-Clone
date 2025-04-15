using UnityEngine;
using UnityEngine.InputSystem;

namespace Input
{
    public class InputService : MonoBehaviour
    {
        [SerializeField] private PlayerInput _playerInput;

        private InputAction _mousePositionAction;
        private InputAction _mouseAction;

        private Vector2 _mousePosition;

        private bool _wasLeftMouseButtonPressedThisFrame;
        private bool _wasLeftMouseButtonReleasedThisFrame;
        private bool _isLeftMouseButtonPressed;

        private void Awake()
        {
            _mousePositionAction = _playerInput.actions["MousePosition"];
            _mouseAction = _playerInput.actions["Mouse"];
        }

        private void Update()
        {
            _mousePosition = _mousePositionAction.ReadValue<Vector2>();

            _wasLeftMouseButtonPressedThisFrame = _mouseAction.WasPressedThisFrame();
            _wasLeftMouseButtonReleasedThisFrame = _mouseAction.WasReleasedThisFrame();
            _isLeftMouseButtonPressed = _mouseAction.IsPressed();
        }

        public Vector2 GetMousePosition() => _mousePosition;
        public bool WasLeftMouseButtonPressedThisFrame() => _wasLeftMouseButtonPressedThisFrame;
        public bool WasLeftMouseButtonReleasedThisFrame() => _wasLeftMouseButtonReleasedThisFrame;
        public bool IsLeftMouseButtonPressed() => _isLeftMouseButtonPressed;
    }
}