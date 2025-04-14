using UnityEngine;

public class SlingShotController
{
    private Camera _mainCamera;

    private Transform _centerTransform;
    private Transform _idleTransform;

    private SlingShotArea _slingShotArea;
    private SlingShotView _slingShotView;
    private SlingShotModel _slingShotModel;
    private InputService _inputService;

    private bool _isClickedWithinArea;

    public SlingShotController(SlingshotConfig config)
    {
        _mainCamera = config.mainCamera;
        _centerTransform = config.centerTransform;
        _idleTransform = config.idleTransform;
        _slingShotArea = config.slingShotArea;
        _slingShotView = config.slingShotView;

        _slingShotModel = new SlingShotModel(config.slingShotSO);

        _slingShotView.Initialize(this, _centerTransform, _idleTransform, _slingShotModel.BirdPositionOffset);
        _slingShotView.SpawnBirdAndSetSlingshotLines();

        _inputService = GameService.Instance.GetInputService();
    }

    public void UpdateSlingshot()
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

            _slingShotView.SetSlingshotLines(slingShotLinesPosition);
            _slingShotView.PositionAndRotateBird(_slingShotModel.SlingshotLinesPosition, _slingShotModel.DirectionNormalized, _slingShotModel.BirdPositionOffset);
        }

        if(_inputService.WasLeftMouseButtonReleased() && _slingShotView.IsBirdOnSlingShot)
        {
            if (GameService.Instance.GetLevelService().AreEnoughTriesLeft())
            {
                _isClickedWithinArea = false;
                _slingShotView.IsBirdOnSlingShot = false;

                _slingShotView.GetSpawnedBird().LaunchBird(_slingShotModel.Direction, _slingShotModel.SlingshotForce);
                _slingShotView.AnimateSlingShot();

                EventService.Instance.OnBirdLeftSlingshotEvent.InvokeEvent();
                GameService.Instance.GetAudioService().PlaySound(AudioType.Elastic_1);

                if (GameService.Instance.GetLevelService().AreEnoughTriesLeft())
                    _slingShotView.SpawnAnotherBird();
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
}
