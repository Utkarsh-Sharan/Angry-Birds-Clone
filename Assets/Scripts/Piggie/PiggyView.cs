using UnityEngine;
using Main;
using Audio;

namespace Piggy
{
    public class PiggyView : MonoBehaviour
    {
        [SerializeField] protected GameObject piggyDeathParticle;
        private PiggyController _piggyController;

        public void Initialize(PiggyController piggieController)
        {
            _piggyController = piggieController;
        }

        protected void OnCollisionEnter2D(Collision2D other)
        {
            _piggyController.OnPiggyCollision(other);
        }

        public void Die()
        {
            GameService.Instance.GetAudioService().PlaySound(AudioTypes.Pop);

            Instantiate(piggyDeathParticle, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}