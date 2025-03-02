using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SlingShotController : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;

    [SerializeField] private LineRenderer _leftLineRenderer;
    [SerializeField] private LineRenderer _rightLineRenderer;
    [SerializeField] private Transform _leftStartTransform;
    [SerializeField] private Transform _rightStartTransform;
    [SerializeField] private Transform _centerPosition;
    [SerializeField] private Transform _idlePosition;

    [SerializeField] private float _maxDistance = 3.5f;

    private Vector2 _slingShotLinesPosition;

    private void Update()
    {
        if (Mouse.current.leftButton.isPressed)
        {
            DrawSlingShot();
        }
    }

    private void DrawSlingShot()
    {
        Vector3 touchPosition = _mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        _slingShotLinesPosition = _centerPosition.position + Vector3.ClampMagnitude(touchPosition - _centerPosition.position, _maxDistance);
        SetLines(_slingShotLinesPosition);
    }

    private void SetLines(Vector2 position)
    {
        _leftLineRenderer.SetPosition(0, position);
        _leftLineRenderer.SetPosition(1, _leftStartTransform.position);

        _rightLineRenderer.SetPosition(0, position);
        _rightLineRenderer.SetPosition(1, _rightStartTransform.position);
    }
}
