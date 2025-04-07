using System.Collections.Generic;
using UnityEngine;

public class NormalPiggyController : PiggyController
{
    public NormalPiggyController()
    {
        piggyType = PiggyType.Normal;

        damageThreshold = piggyStatsDictionary[PiggyType.Normal].DamageThreshold;
        currentHealth = piggyStatsDictionary[PiggyType.Normal].MaxHealth;
    }
}
