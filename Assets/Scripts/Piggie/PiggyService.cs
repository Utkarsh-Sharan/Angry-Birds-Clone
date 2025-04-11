using System;
using System.Collections.Generic;
using UnityEngine;

public class PiggyService
{
    private List<PiggiesToSpawn> _piggiesToSpawnList;
    private Dictionary<PiggyType, Action<PiggyView, PiggyScriptableObject, Vector2>> _piggiesSpawnDictionary;

    public PiggyService(List<PiggyScriptableObject> piggySOList)
    {
        _piggiesToSpawnList = GameService.Instance.GetLevelService().GetPiggiesToSpawnList();

        InitializeSpawnDictionary();
        CreateChildControllers();
    }

    //WORKING of InitializeSpawnDictionary():
    //1. Creating a dictionary which maps each PiggyType to an Action which spawns that piggy.
    //2. Key is the piggy type.
    //3. Value is the lambda expression, acting like a constructor delegate (treating a class constructor like a function).
    //4. Instead of calling the constructor directly, I have created a "delegate" which knows how to create that object.
    private void InitializeSpawnDictionary()
    {
        _piggiesSpawnDictionary = new Dictionary<PiggyType, Action<PiggyView, PiggyScriptableObject, Vector2>>
        {
            {PiggyType.Normal, (view, scriptableObject, position) => new NormalPiggyController(view, scriptableObject, position) },
            //we can simply add more piggy types here. No need for switch-case or if-else ladder.
        };
    }

    private void CreateChildControllers()
    {
        foreach (PiggiesToSpawn piggies in _piggiesToSpawnList)
        {
            for (int i = 0; i < piggies.NumberOfPiggies; ++i)
            {
                _piggiesSpawnDictionary[piggies.PiggyType].Invoke(piggies.PiggyView, piggies.PiggyScriptableObject, piggies.SpawnPositionList[i]);
            }
        }
    }
}
