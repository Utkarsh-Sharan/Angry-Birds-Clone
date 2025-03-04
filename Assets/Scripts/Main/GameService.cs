using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameService : MonoBehaviour
{
    private static GameService _instance;
    public static GameService Instance { get { return _instance; } }

    [SerializeField] private LevelController _levelController;

    private void Awake()
    {
        if(_instance == null)
            _instance = this;
    }

    public LevelController GetLevelController() => _levelController;
}
