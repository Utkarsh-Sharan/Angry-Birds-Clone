using System.Collections.Generic;
using UnityEngine;

public class PiggieController : MonoBehaviour
{
    [SerializeField] protected GameObject _piggyDeathParticle;

    protected PiggyType piggyType;
    protected Dictionary<PiggyType, PiggyStats> piggyStatsDictionary;

    protected float currentHealth;
    protected float damageThreshold;

    public virtual void Initialize(List<PiggyScriptableObject> piggySOList)
    {
        piggyStatsDictionary = new Dictionary<PiggyType, PiggyStats>();

        foreach(PiggyScriptableObject piggySO in piggySOList)
            piggyStatsDictionary[piggySO.PiggyType] = piggySO.PiggyStats;
    }

    private void DamagePiggie(float damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth < 0)
            Die();
    }

    private void Die()
    {
        GameService.Instance.GetLevelService().RemovePiggyFromLevelList(this);
        GameService.Instance.GetAudioService().PlaySound(AudioType.Pop);

        Instantiate(_piggyDeathParticle, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }

    protected void OnCollisionEnter2D(Collision2D other)
    {
        float impactVelocity = other.relativeVelocity.magnitude;

        if (impactVelocity > damageThreshold)
            DamagePiggie(impactVelocity);
    }
}
