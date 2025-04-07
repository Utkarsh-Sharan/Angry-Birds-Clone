using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    private const float TIME_TO_DECIDE_RESULT = 3f;

    private Level _currentLevel;
    private int _maxTries;
    private int _triesLeft;

    private List<PiggieController> _piggies;

    public void Initialize(LevelScriptableObject levelSO)
    {
        _maxTries = levelSO.MaxTries;

        //foreach (LevelData level in levelSO.LevelDataList)
        //{
        //    _currentLevel = level.Level;
        //}

        _currentLevel = Level.Level_1;
        _piggies = new List<PiggieController>();
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

    public void AddPiggyToLevelList(PiggieController piggy) 
    {
        _piggies.Add(piggy);
    }

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
