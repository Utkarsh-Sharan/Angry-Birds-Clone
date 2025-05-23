using System.Collections.Generic;
using UnityEngine;
using UI;
using Slingshot;
using Audio;
using Cameras;
using Input;
using Level;
using Piggy;

namespace Main
{
    public class GameService : GenericMonoSingleton<GameService>
    {
        [Header("Controllers")]
        [SerializeField] private LevelController _levelController;
        [SerializeField] private AudioController _audioController;
        [SerializeField] private CameraController _cameraController;

        [Header("Services")]
        [SerializeField] private UIService _uIService;
        [SerializeField] private InputService _inputService;

        [Header("Sling Shot Properties")]
        [SerializeField] private Camera _mainCamera;
        [SerializeField] private Transform _centerTransform;
        [SerializeField] private Transform _idleTransform;
        [SerializeField] private SlingShotArea _slingShotArea;
        [SerializeField] private SlingShotView _slingShotView;

        [Header("Audio Properties")]
        [SerializeField] private AudioSource _audioSource;

        [Header("Scriptable Objects")]
        [SerializeField] private LevelScriptableObject _levelSO;
        [SerializeField] private SlingshotScriptableObject _slingShotSO;
        [SerializeField] private List<AudioScriptableObject> _audioSOList;

        private LevelService _levelService;
        private PiggyService _piggyService;
        private SlingshotConfig _slingshotConfig;
        private SlingShotService _slingShotService;
        private AudioService _audioService;
        private CameraService _cameraService;

        protected override void Awake()
        {
            base.Awake();

            CreateServices();
        }

        private void CreateServices()
        {
            _levelService = new LevelService(_levelController, _levelSO);
            _slingshotConfig = new SlingshotConfig
            {
                slingShotSO = _slingShotSO,
                mainCamera = _mainCamera,
                centerTransform = _centerTransform,
                idleTransform = _idleTransform,
                slingShotArea = _slingShotArea,
                slingShotView = _slingShotView,
            };
            _slingShotService = new SlingShotService(_slingshotConfig);
            _cameraService = new CameraService(_cameraController);
            _piggyService = new PiggyService();
            _audioService = new AudioService(_audioController, _audioSOList, _audioSource);
        }

        public LevelService GetLevelService() => _levelService;
        public UIService GetUIService() => _uIService;
        public InputService GetInputService() => _inputService;
        public AudioService GetAudioService() => _audioService;
        public CameraService GetCameraService() => _cameraService;
    }
}