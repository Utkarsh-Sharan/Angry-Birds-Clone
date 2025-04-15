using UnityEngine;
using Main;
using Audio;

namespace Bird
{
    public class BirdView : MonoBehaviour
    {
        [SerializeField] protected Rigidbody2D _birdRigidBody;
        [SerializeField] protected CircleCollider2D _birdCollider;

        private bool _isBirdLaunched = false;
        private bool _shouldFaceVelocityDirection = false;

        private BirdController _birdController;

        public void Initialize(BirdController birdController)
        {
            _birdRigidBody.isKinematic = true;
            _birdCollider.enabled = false;

            _birdController = birdController;
        }

        private void FixedUpdate()
        {
            //if (_isBirdLaunched && _shouldFaceVelocityDirection)
            //    transform.right = _birdRigidBody.velocity;

            _birdController?.FixedUpdateBird();
        }

        public void LaunchBird(Vector2 direction, float force)
        {
            _birdRigidBody.isKinematic = false;
            _birdCollider.enabled = true;
            _isBirdLaunched = true;
            _shouldFaceVelocityDirection = true;

            _birdRigidBody.AddForce(direction * force, ForceMode2D.Impulse);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            //_shouldFaceVelocityDirection = false;
            //GameService.Instance.GetAudioService().PlaySound(AudioTypes.Box_Hit);
            _birdController.OnCollision(other);
            Destroy(this);
        }

        public Rigidbody2D GetBirdRigidbody() => _birdRigidBody;
        public CircleCollider2D GetBirdCollider() => _birdCollider;
    }
}