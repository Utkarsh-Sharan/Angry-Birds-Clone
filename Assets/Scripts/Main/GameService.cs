using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameService : MonoBehaviour
{
    private static GameService _instance;
    public static GameService Instance { get { return _instance; } }

    [Header("Controllers")]
    [SerializeField] private LevelController _levelController;
    [SerializeField] private AudioController _audioController;
    [SerializeField] private CameraController _cameraController;

    [SerializeField] private UIService _uIService;
    [SerializeField] private InputService _inputService;

    [Header("Audio Properties")]
    [SerializeField] private List<AudioScriptableObject> _audioSOList;
    [SerializeField] private AudioSource _audioSource;

    private LevelService _levelService;
    private AudioService _audioService;
    private CameraService _cameraService;

    private void Awake()
    {
        if(_instance == null)
            _instance = this;

        CreateServices();
    }

    private void CreateServices()
    {
        _levelService = new LevelService(_levelController);
        _audioService = new AudioService(_audioController, _audioSOList, _audioSource);
        _cameraService = new CameraService(_cameraController);
    }

    public LevelService GetLevelService() => _levelService;
    public UIService GetUIService() => _uIService;
    public InputService GetInputService() => _inputService;
    public AudioService GetAudioService() => _audioService;
    public CameraService GetCameraService() => _cameraService;
}
