using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Main;
using Event;

public class LevelController : MonoBehaviour
{
    private const float TIME_TO_DECIDE_RESULT = 3f;

    public LevelNumber CurrentLevel { get; set; }
    private int _maxTries;
    private int _tries;
    private int _totalEnemiesInThisLevel;

    private Dictionary<LevelNumber, (int, List<PiggiesToSpawn>)> _levelDictionary;
    private List<PiggiesToSpawn> _piggiesToSpawnList;

    public void Initialize(LevelScriptableObject levelSO)
    {
        _levelDictionary = new Dictionary<LevelNumber, (int, List<PiggiesToSpawn>)>();

        foreach (LevelData level in levelSO.LevelDataList)
            _levelDictionary[level.LevelNumber] = (level.MaxTriesForThisLevel, level.PiggiesToSpawnList);

        _maxTries = _levelDictionary[CurrentLevel].Item1;
        _piggiesToSpawnList = _levelDictionary[CurrentLevel].Item2;

        CalculateTotalEneiesInThisLevel();

        EventService.Instance.OnBirdLeftSlingshotEvent.AddListener(IncreaseTries);
    }

    private void CalculateTotalEneiesInThisLevel()
    {
        foreach (PiggiesToSpawn piggies in _piggiesToSpawnList)
            _totalEnemiesInThisLevel += piggies.NumberOfPiggies;
    }

    public bool AreEnoughTriesLeft() => _tries < _maxTries;

    public void EnemyKilled()
    {
        --_totalEnemiesInThisLevel;
        if (_totalEnemiesInThisLevel == 0)
            GameWon();
    }

    private void IncreaseTries()
    {
        ++_tries;
        CheckForLastTry();
    }

    private void CheckForLastTry()
    {
        if (_tries == _maxTries)
            StartCoroutine(CheckForAllPiggiesDead());
    }

    private IEnumerator CheckForAllPiggiesDead()
    {
        yield return new WaitForSeconds(TIME_TO_DECIDE_RESULT);

        if (CheckIfAllPiggiesAreDead())
            yield return null;
        else
            GameLost();
    }

    private bool CheckIfAllPiggiesAreDead()
    {
        if(_totalEnemiesInThisLevel == 0)
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

    public List<PiggiesToSpawn> GetPiggiesToSpawnList() => _piggiesToSpawnList;

    private void OnDisable()
    {
        EventService.Instance.OnBirdLeftSlingshotEvent.RemoveListener(IncreaseTries);
    }
}
