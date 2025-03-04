using UnityEngine;
using UnityEngine.InputSystem;

public class SlingShotModel
{
    private float _maxDistance = 3.5f;
    private float _birdPositionOffset = 0.3f;
    private float _slingShotForce = 5f;
    private Vector2 _slingShotLinesPosition;
    private Vector2 _direction;
    private Vector2 _directionNormalized;
    private SlingShotView _slingShotView;

    public SlingShotModel(SlingShotView slingShotView, Transform centerTransform, Transform idleTransform)
    {
        _slingShotView = slingShotView;
    }

    public void DrawSlingShot(Camera mainCamera, Transform centerTransform)
    {
        Vector3 touchPosition = mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        _slingShotLinesPosition = centerTransform.position + Vector3.ClampMagnitude(touchPosition - centerTransform.position, _maxDistance);
        _slingShotView.SetLines(_slingShotLinesPosition);

        _direction = (Vector2)centerTransform.position - _slingShotLinesPosition;
        _directionNormalized = _direction.normalized;
    }

    public void PositionAndRotateBird() => _slingShotView.PositionAndRotateBird(_slingShotLinesPosition, _directionNormalized, _birdPositionOffset);

    public Vector2 GetDirection() => _direction;

    public float GetSlingShotForce() => _slingShotForce;

    public float GetBirdPositionOffset() => _birdPositionOffset;
}
