using System.Collections.Generic;
using UnityEngine;

public class PiggyController
{
    protected Dictionary<PiggyType, PiggyStats> piggyStatsDictionary;

    protected float currentHealth;
    protected float damageThreshold;

    public PiggyController(List<PiggyScriptableObject> piggySOList)
    {
        piggyStatsDictionary = new Dictionary<PiggyType, PiggyStats>();

        foreach(PiggyScriptableObject piggySO in piggySOList)
            piggyStatsDictionary[piggySO.PiggyType] = piggySO.PiggyStats;
    }

    public PiggyController() { }

    public virtual void OnPiggyCollision(Collision2D other) { }
}
