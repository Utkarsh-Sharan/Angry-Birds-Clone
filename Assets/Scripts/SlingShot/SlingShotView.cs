using UnityEngine;

public class SlingShotView : MonoBehaviour
{
    [Header("Line Renderers")]
    [SerializeField] private LineRenderer _leftlineRenderer;
    [SerializeField] private LineRenderer _rightlineRenderer;

    [Header("Transform references")]
    [SerializeField] private Transform _leftStartTransform;
    [SerializeField] private Transform _rightStartTransform;

    [SerializeField] private GameObject _birdPrefab;

    private GameObject _spawnedBird;

    private void Awake()
    {
        _leftlineRenderer.enabled = false;
        _rightlineRenderer.enabled = false;
    }

    public void SpawnBird(Transform centerTransform, Transform idleTransform, float birdPositionOffset)
    {
        SetLines(idleTransform.position);

        Vector2 direction = (centerTransform.position - idleTransform.position).normalized;
        Vector2 spawnPosition = (Vector2)idleTransform.position + direction * birdPositionOffset;

        _spawnedBird = Instantiate(_birdPrefab, spawnPosition, Quaternion.identity);
        _spawnedBird.transform.right = direction;
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
}
