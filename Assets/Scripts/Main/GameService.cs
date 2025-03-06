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

    private AudioService _audioService;

    private void Awake()
    {
        if(_instance == null)
            _instance = this;

        CreateServices();
    }

    public void CreateServices()
    {
        _audioService = new AudioService(_audioController, _audioSOList, _audioSource);
    }

    public LevelController GetLevelController() => _levelController;
    public UIService GetUIService() => _uIService;
    public InputService GetInputService() => _inputService;
    public AudioService GetAudioService() => _audioService;
}
