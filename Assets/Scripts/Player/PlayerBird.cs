using UnityEngine;

public class PlayerBird : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _birdRigidBody;
    [SerializeField] private CircleCollider2D _birdCollider;

    private void Awake()
    {
        _birdRigidBody.isKinematic = true;
        _birdCollider.enabled = false;
    }

    public void LaunchBird(Vector2 direction, float force)
    {
        _birdRigidBody.isKinematic = false;
        _birdCollider.enabled = true;
    }
}
