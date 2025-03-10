using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelService
{
    private LevelController _levelController;

    public LevelService(LevelController levelController)
    {
        _levelController = levelController;
    }

    public bool AreEnoughTriesLeft() => _levelController.AreEnoughTriesLeft();
    public void IncreaseTries() => _levelController.IncreaseTries();
    public void AddPiggyToLevelList(PiggieController piggy) => _levelController.AddPiggyToLevelList(piggy);
    public void RemovePiggyFromLevelList(PiggieController piggy) => _levelController.RemovePiggyFromLevelList(piggy);
}
