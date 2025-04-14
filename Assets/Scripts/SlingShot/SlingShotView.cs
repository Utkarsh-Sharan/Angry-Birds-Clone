using System.Collections;
using UnityEngine;
using DG.Tweening;

public class SlingShotView : MonoBehaviour
{
    [Header("Line Renderers")]
    [SerializeField] private LineRenderer _leftlineRenderer;
    [SerializeField] private LineRenderer _rightlineRenderer;

    [Header("Transform references")]
    [SerializeField] private Transform _leftStartTransform;
    [SerializeField] private Transform _rightStartTransform;
    [SerializeField] private Transform _elasticTransform;

    [Header("Scripts")]
    [SerializeField] private BirdController _birdPrefab;

    [Header("Animation Curve")]
    [SerializeField] private AnimationCurve _elasticCurve;

    private BirdController _spawnedBird;

    private Transform _centerTransform;
    private Transform _idleTransform;
    private float _birdPositionOffset;
    private float _elasticDivider = 1.2f;
    public bool IsBirdOnSlingShot { get; set; }

    public void Initialize(Transform centerTransform, Transform idleTransform, float birdPositionOffset)
    {
        _centerTransform = centerTransform;
        _idleTransform = idleTransform;
        _birdPositionOffset = birdPositionOffset;
        
        _leftlineRenderer.enabled = false;
        _rightlineRenderer.enabled = false;
    }

    public void SpawnBird()
    {
        SetLines(_idleTransform.position);

        Vector2 direction = (_centerTransform.position - _idleTransform.position).normalized;
        Vector2 spawnPosition = (Vector2)_idleTransform.position + direction * _birdPositionOffset;

        _spawnedBird = Instantiate(_birdPrefab, spawnPosition, Quaternion.identity);
        _spawnedBird.transform.right = direction;

        IsBirdOnSlingShot = true;
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

    public void AnimateSlingShot()
    {
        _elasticTransform.position = _leftlineRenderer.GetPosition(0);

        float distance = Vector2.Distance(_elasticTransform.position, _centerTransform.position);
        float time = distance / _elasticDivider;

        _elasticTransform.DOMove(_centerTransform.position, time).SetEase(_elasticCurve);
        StartCoroutine(AnimateSlingShotLines(_elasticTransform, time));
    }

    private IEnumerator AnimateSlingShotLines(Transform transform, float time)
    {
        float elapsedTime = 0;
        while (elapsedTime < time)
        {
            elapsedTime += Time.deltaTime;
            SetLines(transform.position);

            yield return null;
        }
    }

    public BirdController GetSpawnedBird() => _spawnedBird;
}
