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
    private int _life = 3;
    private InputService _inputService;

    private void Awake()
    {
        _inputService = GameService.Instance.GetInputService();

        _slingShotModel = new SlingShotModel();
        _slingShotView.Initialize(_centerTransform, _idleTransform, _slingShotModel.GetBirdPositionOffset());
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

        if(_inputService.IsLeftMouseButtonPressed() && _isClickedWithinArea && _slingShotView.GetBirdStatus())
        {
            Vector2 slingShotLinesPosition = _slingShotModel.DrawSlingShot(_mainCamera, _centerTransform);

            _slingShotView.SetLines(slingShotLinesPosition);
            _slingShotView.PositionAndRotateBird(_slingShotModel.GetSlingShotLinesPosition(), _slingShotModel.GetDirectionNormalized(), _slingShotModel.GetBirdPositionOffset());
        }

        if(_inputService.WasLeftMouseButtonReleased() && _slingShotView.GetBirdStatus())
        {
            if (GameService.Instance.GetLevelController().AreEnoughTriesLeft())
            {
                _isClickedWithinArea = false;

                _slingShotView.GetSpawnedBird().LaunchBird(_slingShotModel.GetDirection(), _slingShotModel.GetSlingShotForce());
                _slingShotView.SetBirdStatus(false);
                _slingShotView.AnimateSlingShot();

                GameService.Instance.GetUIService().DecreaseLife(--_life);
                GameService.Instance.GetLevelController().IncreaseTries();
                GameService.Instance.GetAudioService().PlaySound(AudioType.Elastic_1);

                if (GameService.Instance.GetLevelController().AreEnoughTriesLeft())
                    StartCoroutine(SpawnBirdAfterSomeTime());
            }
        }
    }

    private IEnumerator SpawnBirdAfterSomeTime()
    {
        yield return new WaitForSeconds(2f);
        _slingShotView.SpawnBird();
        GameService.Instance.GetCameraService().SwitchToIdleCamera();
    }
}
