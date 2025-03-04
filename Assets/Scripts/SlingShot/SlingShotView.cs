using System.Collections;
using UnityEngine;

public class SlingShotView : MonoBehaviour
{
    [Header("Line Renderers")]
    [SerializeField] private LineRenderer _leftlineRenderer;
    [SerializeField] private LineRenderer _rightlineRenderer;

    [Header("Transform references")]
    [SerializeField] private Transform _leftStartTransform;
    [SerializeField] private Transform _rightStartTransform;

    [SerializeField] private PlayerBird _birdPrefab;

    private PlayerBird _spawnedBird;

    private Transform _centerTransform;
    private Transform _idleTransform;
    private float _birdPositionOffset;

    private bool _isBirdOnSlingShot = false;

    private void Awake()
    {
        _leftlineRenderer.enabled = false;
        _rightlineRenderer.enabled = false;
    }

    public void Initialize(Transform centerTransform, Transform idleTransform, float birdPositionOffset)
    {
        _centerTransform = centerTransform;
        _idleTransform = idleTransform;
        _birdPositionOffset = birdPositionOffset;
    }

    public void SpawnBird()
    {
        SetLines(_idleTransform.position);

        Vector2 direction = (_centerTransform.position - _idleTransform.position).normalized;
        Vector2 spawnPosition = (Vector2)_idleTransform.position + direction * _birdPositionOffset;

        _spawnedBird = Instantiate(_birdPrefab, spawnPosition, Quaternion.identity);
        _spawnedBird.transform.right = direction;

        _isBirdOnSlingShot = true;
    }

    public void PositionAndRotateBird(Vector2 slingShotLinesPosition, Vector2 directionNormalized, float birdPositionOffset)
    {
        _spawnedBird.transform.position = slingShotLinesPosition + directionNormalized * birdPositionOffset;
        _spawnedBird.transform.right = directionNormalized;
    }

    public void SetLines(Vector2 position)
    {
        if(!_leftlineRenderer.enabled && !_rightlineRenderer.enabled)
        {
            _leftlineRenderer.enabled = true;
            _rightlineRenderer.enabled = true;
        }

        _leftlineRenderer.SetPosition(0, position);
        _leftlineRenderer.SetPosition(1, _leftStartTransform.position);

        _rightlineRenderer.SetPosition(0, position);
        _rightlineRenderer.SetPosition(1, _rightStartTransform.position);
    }

    public IEnumerator SpawnBirdAfterSomeTime()
    {
        yield return new WaitForSeconds(2f);

        SpawnBird();
    }

    public PlayerBird GetSpawnedBird() => _spawnedBird;

    public bool GetBirdStatus() => _isBirdOnSlingShot;

    public void SetBirdStatus(bool birdStatus) => _isBirdOnSlingShot = birdStatus;
}
