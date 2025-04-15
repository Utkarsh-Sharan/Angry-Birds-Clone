using UnityEngine;
using Main;

namespace Piggy
{
    public class NormalPiggyController : PiggyController
    {
        private NormalPiggyView _normalPiggyView;

        public NormalPiggyController(PiggyView piggyView, PiggyScriptableObject piggySO, Vector2 spawnPosition)
        {
            _normalPiggyView = (NormalPiggyView)Object.Instantiate(piggyView, spawnPosition, Quaternion.identity);
            _normalPiggyView.Initialize(this);

            currentHealth = piggySO.PiggyStats.MaxHealth;
            damageThreshold = piggySO.PiggyStats.DamageThreshold;
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
}