using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelService
{
    private LevelController _levelController;

    public LevelService(LevelController levelController, LevelScriptableObject levelSO)
    {
        _levelController = levelController;
        _levelController.CurrentLevel = LevelNumber.Level_1;

        _levelController.Initialize(levelSO);
    }

    public bool AreEnoughTriesLeft() => _levelController.AreEnoughTriesLeft();
    public void IncreaseTries() => _levelController.IncreaseTries();
    public void AddPiggyToLevelList(PiggyView piggy) => _levelController.AddPiggyToLevelList(piggy);
    public void RemovePiggyFromLevelList(PiggyView piggy) => _levelController.RemovePiggyFromLevelList(piggy);
}
