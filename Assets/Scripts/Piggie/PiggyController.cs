using System.Collections.Generic;
using UnityEngine;

public class PiggyController
{
    protected PiggyType piggyType;
    protected Dictionary<PiggyType, PiggyStats> piggyStatsDictionary;

    protected float currentHealth;
    protected float damageThreshold;

    private PiggyView _piggyView;

    public PiggyController() { }

    public PiggyController(List<PiggyScriptableObject> piggySOList)
    {
        piggyStatsDictionary = new Dictionary<PiggyType, PiggyStats>();

        foreach(PiggyScriptableObject piggySO in piggySOList)
            piggyStatsDictionary[piggySO.PiggyType] = piggySO.PiggyStats;

        //instantiate piggy views here according to level data.
    }

    public void OnPiggyCollision(Collision2D other)
    {
        float impactVelocity = other.relativeVelocity.magnitude;

        if (impactVelocity > damageThreshold)
            DamagePiggie(impactVelocity);
    }

    private void DamagePiggie(float damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth < 0)
            _piggyView.Die();
    }
}
