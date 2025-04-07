using System.Collections.Generic;
using UnityEngine;

public class PiggyController
{
    protected PiggyType piggyType;
    protected Dictionary<PiggyType, PiggyStats> piggyStatsDictionary;

    protected float currentHealth;
    protected float damageThreshold;

    public PiggyController() { }

    public PiggyController(List<PiggyScriptableObject> piggySOList)
    {
        piggyStatsDictionary = new Dictionary<PiggyType, PiggyStats>();

        foreach(PiggyScriptableObject piggySO in piggySOList)
            piggyStatsDictionary[piggySO.PiggyType] = piggySO.PiggyStats;

        //create piggy controllers here according to level data.
    }

    public virtual void OnPiggyCollision(Collision2D other) { }
}
