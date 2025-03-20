using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalPiggyController : PiggieController
{
    public override void Initialize(List<PiggyScriptableObject> piggySOList)
    {
        base.Initialize(piggySOList);

        this.piggyType = PiggyType.Normal;
        this.damageThreshold = piggyStatsDictionary[this.piggyType].DamageThreshold;

        this.currentHealth = piggyStatsDictionary[this.piggyType].MaxHealth;

        GameService.Instance.GetLevelService().AddPiggyToLevelList(this);
    }
}
