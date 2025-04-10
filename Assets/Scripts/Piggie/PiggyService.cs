using System.Collections.Generic;
using UnityEngine;

public class PiggyService
{
    private List<PiggiesToSpawn> _piggiesToSpawnList;

    public PiggyService(List<PiggyScriptableObject> piggySOList)
    {
        PiggyController piggyController = new PiggyController(piggySOList); //follow spawning just like sword fight. See sword fight github.

        _piggiesToSpawnList = GameService.Instance.GetLevelService().GetPiggiesToSpawnList();

        CreateChildControllers();
    }

    private void CreateChildControllers()
    {
        foreach (PiggiesToSpawn piggies in _piggiesToSpawnList)
        {
            for (int i = 0; i < piggies.NumberOfPiggies; ++i)
            {
                switch (piggies.PiggyType)
                {
                    case PiggyType.Normal:
                        new NormalPiggyController(piggies.PiggyView, piggies.SpawnPositionList);
                        break;
                    default:
                        Debug.Log("No such piggy typee exists!");
                        break;
                }
            }
        }
    }
}
