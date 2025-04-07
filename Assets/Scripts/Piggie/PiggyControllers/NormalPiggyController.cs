using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalPiggyController : PiggieController
{
    public override void Initialize(List<PiggyScriptableObject> piggySOList)
    {
        base.Initialize(piggySOList);

        piggyType = PiggyType.Normal;
        damageThreshold = piggyStatsDictionary[piggyType].DamageThreshold;

        currentHealth = piggyStatsDictionary[piggyType].MaxHealth;

        GameService.Instance.GetLevelService().AddPiggyToLevelList(this);
    }
}
