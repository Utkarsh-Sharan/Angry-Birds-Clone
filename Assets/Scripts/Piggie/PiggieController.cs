using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiggieController : MonoBehaviour
{
    [SerializeField] private GameObject _piggyDeathParticle;

    private float _maxHealth = 3f;
    private float _currentHealth;
    private float _damageThreshold = 0.2f;

    private void Start()
    {
        _currentHealth = _maxHealth;
        GameService.Instance.GetLevelController().AddPiggyToLevelList(this);
    }

    private void DamagePiggie(float damageAmount)
    {
        _currentHealth -= damageAmount;
        if (_currentHealth < 0)
            Die();
    }

    private void Die()
    {
        GameService.Instance.GetLevelController().RemovePiggyFromLevelList(this);
        Instantiate(_piggyDeathParticle, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        float impactVelocity = other.relativeVelocity.magnitude;

        if (impactVelocity > _damageThreshold)
            DamagePiggie(impactVelocity);
    }
}
