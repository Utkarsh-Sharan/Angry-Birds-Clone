using UnityEngine;

namespace Bird
{
    public class BirdView : MonoBehaviour
    {
        [SerializeField] protected Rigidbody2D _birdRigidBody;
        [SerializeField] protected CircleCollider2D _birdCollider;

        private BirdController _birdController;

        public void Initialize(BirdController birdController)
        {
            _birdRigidBody.isKinematic = true;
            _birdCollider.enabled = false;

            _birdController = birdController;
        }

        private void FixedUpdate()
        {
            _birdController?.FixedUpdateBird();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            _birdController.OnCollision(other);
            Destroy(this);
        }

        public Rigidbody2D GetBirdRigidbody() => _birdRigidBody;
        public CircleCollider2D GetBirdCollider() => _birdCollider;
    }
}