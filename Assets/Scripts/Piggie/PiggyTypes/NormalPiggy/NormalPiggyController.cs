using System.Collections.Generic;
using UnityEngine;

public class NormalPiggyController : PiggyController
{
    private NormalPiggyView _normalPiggyView;

    public NormalPiggyController(PiggyView piggyView, List<Vector2> spawnPosition)
    {
        damageThreshold = piggyStatsDictionary[PiggyType.Normal].DamageThreshold;
        currentHealth = piggyStatsDictionary[PiggyType.Normal].MaxHealth;

        //_normalPiggyView = Object.Instantiate(piggyView, spawnPosition, Quaternion.identity);
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
        if (currentHealth < 0)
        {
            GameService.Instance.GetLevelService().EnemyKilled();
            _normalPiggyView.Die();
        }
    }
}
