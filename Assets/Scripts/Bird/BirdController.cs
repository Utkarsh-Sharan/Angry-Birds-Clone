using Audio;
using Main;
using UnityEngine;

namespace Bird
{
    public class BirdController
    {
        private BirdView _birdView; 

        private bool _isBirdLaunched = false;
        private bool _shouldFaceVelocityDirection = false;

        public BirdController(BirdView birdView, Vector2 spawnPosition)
        {
            _birdView = Object.Instantiate(birdView, spawnPosition, Quaternion.identity);
            _birdView.Initialize(this);
        }

        public void FixedUpdateBird()
        {
            if (_isBirdLaunched && _shouldFaceVelocityDirection)
                _birdView.transform.right = _birdView.GetBirdRigidbody().velocity;
        }

        public void LaunchBird(Vector2 direction, float force)
        {
            _birdView.GetBirdRigidbody().isKinematic = false;
            _birdView.GetBirdCollider().enabled = true;

            _isBirdLaunched = true;
            _shouldFaceVelocityDirection = true;

            _birdView.GetBirdRigidbody().AddForce(direction * force, ForceMode2D.Impulse);
        }

        public void OnCollision(Collision2D other)
        {
            _shouldFaceVelocityDirection = false;
            GameService.Instance.GetAudioService().PlaySound(AudioTypes.Box_Hit);
        }
    }
}