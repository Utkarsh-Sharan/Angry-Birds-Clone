using System.Collections.Generic;
using UnityEngine;

public class PiggyController
{
    protected float currentHealth;
    protected float damageThreshold;

    public virtual void OnPiggyCollision(Collision2D other) { }
}
