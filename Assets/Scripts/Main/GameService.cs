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

    [SerializeField] private UIService _uIService;
    [SerializeField] private InputService _inputService;

    [Header("Audio Properties")]
    [SerializeField] private List<AudioScriptableObject> _audioSOList;
    [SerializeField] private AudioSource _audioSource;

    [Header("Camera Properties")]
    [SerializeField] private CameraController _cameraController;

    private AudioService _audioService;
    private CameraService _cameraService;

    private void Awake()
    {
        if(_instance == null)
            _instance = this;

        CreateServices();
    }

    public void CreateServices()
    {
        _audioService = new AudioService(_audioController, _audioSOList, _audioSource);
        _cameraService = new CameraService(_cameraController);
    }

    public LevelController GetLevelController() => _levelController;
    public UIService GetUIService() => _uIService;
    public InputService GetInputService() => _inputService;
    public AudioService GetAudioService() => _audioService;
    public CameraService GetCameraService() => _cameraService;
}
