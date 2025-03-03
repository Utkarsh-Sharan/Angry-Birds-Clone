using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SlingShotController : MonoBehaviour
{
    [Header("Camera")]
    [SerializeField] private Camera _mainCamera;

    [Header("Line Renderers")]
    [SerializeField] private LineRenderer _leftLineRenderer;
    [SerializeField] private LineRenderer _rightLineRenderer;

    [Header("Transform References")]
    [SerializeField] private Transform _leftStartTransform;
    [SerializeField] private Transform _rightStartTransform;
    [SerializeField] private Transform _centerTransform;
    [SerializeField] private Transform _idleTransform;

    [Header("Scripts")]
    [SerializeField] private SlingShotArea _slingShotArea;

    [Header("Sling Shot Data")]
    [SerializeField] private float _maxDistance = 3.5f;

    [SerializeField] private GameObject _birdPrefab;

    private Vector2 _slingShotLinesPosition;
    private GameObject _spawnedBird;
    private bool _isClickedWithinArea;

    private void Awake()
    {
        _leftLineRenderer.enabled = false;
        _rightLineRenderer.enabled = false;

        SpawnBird();
    }

    private void Update()
    {
        if(Mouse.current.leftButton.wasPressedThisFrame && _slingShotArea.IsWithinSlingShotArea())
            _isClickedWithinArea = true;

        if(Mouse.current.leftButton.isPressed && _isClickedWithinArea)
        {
            DrawSlingShot();
            PositionAndRotateBird();
        }

        if (Mouse.current.leftButton.wasReleasedThisFrame)
            _isClickedWithinArea = false;
    }

    private void SpawnBird()
    {
        SetLines(_idleTransform.position);

        _spawnedBird = Instantiate(_birdPrefab, _idleTransform.position, Quaternion.identity);
    }

    private void PositionAndRotateBird()
    {
        _spawnedBird.transform.position = _slingShotLinesPosition;
    }

    #region Sling Shot region
    private void DrawSlingShot()
    {
        Vector3 touchPosition = _mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        _slingShotLinesPosition = _centerTransform.position + Vector3.ClampMagnitude(touchPosition - _centerTransform.position, _maxDistance);
        SetLines(_slingShotLinesPosition);
    }

    private void SetLines(Vector2 position)
    {
        if (!_leftLineRenderer.enabled && !_rightLineRenderer.enabled)
        {
            _leftLineRenderer.enabled = true;
            _rightLineRenderer.enabled = true;
        }

        _leftLineRenderer.SetPosition(0, position);
        _leftLineRenderer.SetPosition(1, _leftStartTransform.position);

        _rightLineRenderer.SetPosition(0, position);
        _rightLineRenderer.SetPosition(1, _rightStartTransform.position);
    }
    #endregion
}
