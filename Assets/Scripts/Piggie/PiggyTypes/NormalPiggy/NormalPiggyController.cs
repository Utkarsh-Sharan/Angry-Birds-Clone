using System.Collections.Generic;
using UnityEngine;

public class NormalPiggyController : PiggyController
{
    private NormalPiggyView _normalPiggyView;

    public NormalPiggyController()
    {
        piggyType = PiggyType.Normal;

        damageThreshold = piggyStatsDictionary[PiggyType.Normal].DamageThreshold;
        currentHealth = piggyStatsDictionary[PiggyType.Normal].MaxHealth;

        //_normalPiggyView = Object.Instantiate(view);
    }

    public override void OnPiggyCollision(Collision2D other)
    {
        float impactVelocity = other.relativeVelocity.magnitude;

        if (impactVelocity > damageThreshold)
            DamagePiggie(impactVelocity);
    }

    private void DamagePiggie(float damageAmount)
    {
        currentHealth -= damageAmount;
        //if (currentHealth < 0)
        //    _piggyView.Die();
    }
}
