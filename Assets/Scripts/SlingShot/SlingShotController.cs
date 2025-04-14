using System.Collections;
using UnityEngine;

public class SlingShotController : MonoBehaviour
{
    private Camera _mainCamera;

    private Transform _centerTransform;
    private Transform _idleTransform;

    private SlingShotArea _slingShotArea;
    private SlingShotView _slingShotView;
    private SlingShotModel _slingShotModel;
    private InputService _inputService;

    private bool _isClickedWithinArea;
    private int _life = 3;

    public void Initialize(Camera mainCamera, Transform centerTransform, Transform idleTransform, SlingShotArea slingShotArea, SlingshotScriptableObject slingShotSO, SlingShotView slingShotView)
    {
        _mainCamera = mainCamera;
        _centerTransform = centerTransform;
        _idleTransform = idleTransform;
        _slingShotArea = slingShotArea;
        _slingShotView = slingShotView;

        _inputService = GameService.Instance.GetInputService();
        _slingShotModel = new SlingShotModel(slingShotSO);

        _slingShotView.Initialize(_centerTransform, _idleTransform, _slingShotModel.BirdPositionOffset);
        _slingShotView.SpawnBird();
    }

    private void Update()
    {
        if(_inputService.WasLeftMouseButtonPressed() && _slingShotArea.IsWithinSlingShotArea())
        {
            _isClickedWithinArea = true;
            GameService.Instance.GetAudioService().PlaySound(AudioType.Leather_Pull);
            GameService.Instance.GetCameraService().SwitchToFollowCamera(_slingShotView.GetSpawnedBird().transform);
        }

        if(_inputService.IsLeftMouseButtonPressed() && _isClickedWithinArea && _slingShotView.IsBirdOnSlingShot)
        {
            Vector2 slingShotLinesPosition = DrawSlingShot();

            _slingShotView.SetLines(slingShotLinesPosition);
            _slingShotView.PositionAndRotateBird(_slingShotModel.SlingshotLinesPosition, _slingShotModel.DirectionNormalized, _slingShotModel.BirdPositionOffset);
        }

        if(_inputService.WasLeftMouseButtonReleased() && _slingShotView.IsBirdOnSlingShot)
        {
            if (GameService.Instance.GetLevelService().AreEnoughTriesLeft())
            {
                _isClickedWithinArea = false;

                _slingShotView.GetSpawnedBird().LaunchBird(_slingShotModel.Direction, _slingShotModel.SlingshotForce);
                _slingShotView.IsBirdOnSlingShot = false;
                _slingShotView.AnimateSlingShot();

                GameService.Instance.GetUIService().DecreaseLife(--_life);
                GameService.Instance.GetLevelService().IncreaseTries();
                GameService.Instance.GetAudioService().PlaySound(AudioType.Elastic_1);

                if (GameService.Instance.GetLevelService().AreEnoughTriesLeft())
                    StartCoroutine(SpawnBirdAfterSomeTime());
            }
        }
    }

    private Vector2 DrawSlingShot()
    {
        Vector3 touchPosition = _mainCamera.ScreenToWorldPoint(GameService.Instance.GetInputService().GetMousePosition());

        _slingShotModel.SlingshotLinesPosition = _centerTransform.position + Vector3.ClampMagnitude(touchPosition - _centerTransform.position, _slingShotModel.MaxDistance);

        _slingShotModel.Direction = (Vector2)_centerTransform.position - _slingShotModel.SlingshotLinesPosition;
        _slingShotModel.DirectionNormalized = _slingShotModel.Direction.normalized;

        return _slingShotModel.SlingshotLinesPosition;
    }

    private IEnumerator SpawnBirdAfterSomeTime()
    {
        yield return new WaitForSeconds(2f);
        _slingShotView.SpawnBird();
        GameService.Instance.GetCameraService().SwitchToIdleCamera();
    }
}
