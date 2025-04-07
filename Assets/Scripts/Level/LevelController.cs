using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    private const float TIME_TO_DECIDE_RESULT = 3f;

    public LevelNumber CurrentLevel { get; set; }
    private int _maxTries;
    private int _tries;

    private Dictionary<LevelNumber, (int, List<EnemiesToSpawn>)> _levelDictionary;
    private List<PiggyView> _piggies;

    public void Initialize(LevelScriptableObject levelSO)
    {
        _levelDictionary = new Dictionary<LevelNumber, (int, List<EnemiesToSpawn>)>();
        _piggies = new List<PiggyView>();

        foreach (LevelData level in levelSO.LevelDataList)
            _levelDictionary[level.LevelNumber] = (level.MaxTriesForThisLevel, level.PiggiesToSpawnList);

        _maxTries = _levelDictionary[CurrentLevel].Item1;
    }

    public bool AreEnoughTriesLeft() => _tries < _maxTries;

    public void IncreaseTries()
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

    public void AddPiggyToLevelList(PiggyView piggy) 
    {
        _piggies.Add(piggy);
    }

    public void RemovePiggyFromLevelList(PiggyView piggy)
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
