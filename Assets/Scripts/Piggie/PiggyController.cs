using System.Collections.Generic;
using UnityEngine;

public class PiggyController
{
    private List<PiggiesToSpawn> _piggiesToSpawnList;
    protected Dictionary<PiggyType, PiggyStats> piggyStatsDictionary;

    protected float currentHealth;
    protected float damageThreshold;

    public PiggyController(List<PiggyScriptableObject> piggySOList)
    {
        piggyStatsDictionary = new Dictionary<PiggyType, PiggyStats>();

        foreach(PiggyScriptableObject piggySO in piggySOList)
            piggyStatsDictionary[piggySO.PiggyType] = piggySO.PiggyStats;

        _piggiesToSpawnList = GameService.Instance.GetLevelService().GetPiggiesToSpawnList();

        CreateChildControllers();
    }

    private void CreateChildControllers()
    {
        foreach (PiggiesToSpawn piggies in _piggiesToSpawnList)
        {
            switch (piggies.PiggyType)
            {
                case PiggyType.Normal:
                    new NormalPiggyController(piggies.PiggyView, piggies.SpawnPositionList);
                    break;
            }
        }
    }

    public PiggyController() { }

    public virtual void OnPiggyCollision(Collision2D other) { }
}
