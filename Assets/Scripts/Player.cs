using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float _power = 5.0f;
    private Rigidbody2D _rigidbody;

    [SerializeField] private Vector2 _minPower;
    [SerializeField] private Vector2 _maxPower;

    private Vector2 _force;
    private Vector2 _startPoint;
    private Vector2 _endPoint;

    private Camera _camera;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _camera = Camera.main;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _startPoint = _camera.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButtonUp(0))
        {
            _endPoint = _camera.ScreenToWorldPoint(Input.mousePosition);

            _force = new Vector2(Mathf.Clamp(_startPoint.x - _endPoint.x, _minPower.x, _maxPower.x), 
                                 Mathf.Clamp(_startPoint.y - _endPoint.y, _minPower.y, _maxPower.y));

            _rigidbody.AddForce(_force * _power, ForceMode2D.Impulse);
        }
    }
}
