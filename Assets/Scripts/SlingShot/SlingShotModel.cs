using UnityEngine;
using UnityEngine.InputSystem;

public class SlingShotModel
{
    private float _maxDistance = 3.5f;
    private float _birdPositionOffset = 0.3f;
    private float _slingShotForce = 9f;
    private Vector2 _slingShotLinesPosition;
    private Vector2 _direction;
    private Vector2 _directionNormalized;

    public Vector2 DrawSlingShot(Camera mainCamera, Transform centerTransform)
    {
        Vector3 touchPosition = mainCamera.ScreenToWorldPoint(GameService.Instance.GetInputService().GetMousePosition());

        _slingShotLinesPosition = centerTransform.position + Vector3.ClampMagnitude(touchPosition - centerTransform.position, _maxDistance);

        _direction = (Vector2)centerTransform.position - _slingShotLinesPosition;
        _directionNormalized = _direction.normalized;

        return _slingShotLinesPosition;
    }

    public Vector2 GetSlingShotLinesPosition() => _slingShotLinesPosition;

    public Vector2 GetDirection() => _direction;

    public Vector2 GetDirectionNormalized() => _directionNormalized;

    public float GetSlingShotForce() => _slingShotForce;

    public float GetBirdPositionOffset() => _birdPositionOffset;
}
