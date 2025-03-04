using UnityEngine;

public class PlayerBird : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _birdRigidBody;
    [SerializeField] private CircleCollider2D _birdCollider;

    private bool _isBirdLaunched = false;
    private bool _shouldFaceVelocityDirection = false;

    private void Awake()
    {
        _birdRigidBody.isKinematic = true;
        _birdCollider.enabled = false;
    }

    private void FixedUpdate()
    {
        if (_isBirdLaunched && _shouldFaceVelocityDirection)
            transform.right = _birdRigidBody.velocity;
    }

    public void LaunchBird(Vector2 direction, float force)
    {
        _birdRigidBody.isKinematic = false;
        _birdCollider.enabled = true;

        _birdRigidBody.AddForce(direction * force, ForceMode2D.Impulse);
        _isBirdLaunched = true;
        _shouldFaceVelocityDirection = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _shouldFaceVelocityDirection = false;
    }
}
