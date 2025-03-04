using System.Collections;
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
        _slingShotModel = new SlingShotModel();
        _slingShotView.Initialize(_centerTransform, _idleTransform, _slingShotModel.GetBirdPositionOffset());
        _slingShotView.SpawnBird();
    }

    private void Update()
    {
        if(Mouse.current.leftButton.wasPressedThisFrame && _slingShotArea.IsWithinSlingShotArea())
            _isClickedWithinArea = true;

        if(Mouse.current.leftButton.isPressed && _isClickedWithinArea && _slingShotView.GetBirdStatus())
        {
            Vector2 slingShotLinesPosition = _slingShotModel.DrawSlingShot(_mainCamera, _centerTransform);
            _slingShotView.SetLines(slingShotLinesPosition);
            _slingShotView.PositionAndRotateBird(_slingShotModel.GetSlingShotLinesPosition(), _slingShotModel.GetDirectionNormalized(), _slingShotModel.GetBirdPositionOffset());
        }

        if(Mouse.current.leftButton.wasReleasedThisFrame && _slingShotView.GetBirdStatus() == true)
        {
            _isClickedWithinArea = false;

            _slingShotView.GetSpawnedBird().LaunchBird(_slingShotModel.GetDirection(), _slingShotModel.GetSlingShotForce());
            _slingShotView.SetBirdStatus(false);
            StartCoroutine(SpawnBirdAfterSomeTime());
        }
    }

    private IEnumerator SpawnBirdAfterSomeTime()
    {
        yield return new WaitForSeconds(2f);
        _slingShotView.SpawnBird();
    }
}
