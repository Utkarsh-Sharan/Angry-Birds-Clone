using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        if (CheckIfAllPiggiesAreDead())
            yield return null;
        else
            GameLost();
    }

    public void AddPiggyToLevelList(PiggieController piggy) => _piggies.Add(piggy);

    public void RemovePiggyFromLevelList(PiggieController piggy)
    {
        _piggies.Remove(piggy);
        CheckIfAllPiggiesAreDead();
    }

    private bool CheckIfAllPiggiesAreDead()
    {
        if(_piggies.Count == 0)
        {
            GameWon();
            return true;
        }

        return false;
    }

    private void GameWon()
    {
        GameService.Instance.GetUIService().DisplayLevelEndScreen(LevelResult.Win);
    }

    private void GameLost()
    {
        GameService.Instance.GetUIService().DisplayLevelEndScreen(LevelResult.Lose);
    }
}
