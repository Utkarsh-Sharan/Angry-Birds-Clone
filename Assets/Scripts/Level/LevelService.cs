using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelService
{
    private LevelController _levelController;

    public LevelService(LevelController levelController, LevelScriptableObject levelSO)
    {
        _levelController = levelController;
        _levelController.CurrentLevel = LevelNumber.Level_1;    //Will have to make level selection panel/scene, containing various level buttons.
                                                                //Selected level will then become current level.

        _levelController.Initialize(levelSO);
    }

    public bool AreEnoughTriesLeft() => _levelController.AreEnoughTriesLeft();
    public void IncreaseTries() => _levelController.IncreaseTries();
    public void EnemyKilled() => _levelController.EnemyKilled();
    public List<PiggiesToSpawn> GetPiggiesToSpawnList() => _levelController.GetPiggiesToSpawnList();
}
