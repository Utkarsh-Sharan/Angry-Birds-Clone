using UnityEngine;
using UnityEngine.InputSystem;

public class SlingShotController : MonoBehaviour
{
    [Header("Camera")]
    [SerializeField] private Camera _mainCamera;

    [Header("Transform References")]
    [SerializeField] private Transform _centerTransform;
    [SerializeField] private Transform _idleTransform;

    [Header("Scripts")]
    [SerializeField] private SlingShotArea _slingShotArea;
    [SerializeField] private SlingShotView _slingShotView;

    private SlingShotModel _slingShotModel;
    private bool _isClickedWithinArea;

    private void Awake()
    {
        _slingShotModel = new SlingShotModel(_slingShotView, _centerTransform, _idleTransform);
    }

    private void Update()
    {
        if(Mouse.current.leftButton.wasPressedThisFrame && _slingShotArea.IsWithinSlingShotArea())
            _isClickedWithinArea = true;

        if(Mouse.current.leftButton.isPressed && _isClickedWithinArea)
        {
            _slingShotModel.DrawSlingShot(_mainCamera, _centerTransform);
            _slingShotModel.PositionAndRotateBird();
        }

        if (Mouse.current.leftButton.wasReleasedThisFrame)
            _isClickedWithinArea = false;
    }
}
