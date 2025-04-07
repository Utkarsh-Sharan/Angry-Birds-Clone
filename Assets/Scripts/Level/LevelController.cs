using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    private const float TIME_TO_DECIDE_RESULT = 3f;

    public Level CurrentLevel { get; set; }
    private int _maxTries;
    private int _triesLeft;

    private List<PiggyView> _piggies;

    public void Initialize(LevelScriptableObject levelSO)
    {
        _maxTries = levelSO.MaxTries;

        //foreach (LevelData level in levelSO.LevelDataList)
        //{
        //    _currentLevel = level.Level;
        //}

        CurrentLevel = Level.Level_1;
        _piggies = new List<PiggyView>();
    }

    public bool AreEnoughTriesLeft() => _triesLeft < _maxTries;

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
