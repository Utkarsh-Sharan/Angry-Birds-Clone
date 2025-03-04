using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    private Level _currentLevel;

    private int _maxTries = 3;
    private int _triesLeft;

    private void Start()
    {
        _currentLevel = Level.Level_1;
    }

    public bool AreEnoughTriesLeft()
    {
        if(_triesLeft < _maxTries)
            return true;

        return false;
    }

    public void IncreaseTries()
    {
        ++_triesLeft;
    }
}
