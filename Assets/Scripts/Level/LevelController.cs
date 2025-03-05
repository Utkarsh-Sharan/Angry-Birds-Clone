using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    private Level _currentLevel;

    private int _maxTries = 3;
    private int _triesLeft;
    private float _timeToDecideWinOrLoss = 3f;

    private List<PiggieController> _piggies;

    private void Awake()
    {
        _currentLevel = Level.Level_1;
        _piggies = new List<PiggieController>();
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
        CheckForLastTry();
    }

    private void CheckForLastTry()
    {
        if (_triesLeft == _maxTries)
            StartCoroutine(CheckForAllPiggiesDead());
    }

    private IEnumerator CheckForAllPiggiesDead()
    {
        yield return new WaitForSeconds(_timeToDecideWinOrLoss);

        if(_piggies.Count < 0)
            GameWon();

        else
            RestartGame();
    }

    public void AddPiggyToLevelList(PiggieController piggy) => _piggies.Add(piggy);

    public void RemovePiggyFromLevelList(PiggieController piggy)
    {
        _piggies.Remove(piggy);
        CheckIfAllPiggiesAreDead();
    }

    private void CheckIfAllPiggiesAreDead()
    {
        if(_piggies.Count == 0)
            GameWon();
    }

    private void GameWon()
    {
        GameService.Instance.GetUIService().DisplayRestartScreen();
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
