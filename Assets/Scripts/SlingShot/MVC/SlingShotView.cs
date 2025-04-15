using System.Collections;
using UnityEngine;
using DG.Tweening;
using Main;
using Constant;
using Bird;

namespace Slingshot
{
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
        [SerializeField] private BirdView _birdPrefab;

        [Header("Animation Curve")]
        [SerializeField] private AnimationCurve _elasticCurve;

        private SlingShotController _slingShotController;
        private BirdView _spawnedBird;

        private Transform _centerTransform;
        private Transform _idleTransform;
        private float _birdPositionOffset;
        private float _elasticDivider;
        public bool IsBirdOnSlingShot { get; set; }

        public void Initialize(SlingShotController slingShotController, SlingshotConfig config, float birdPositionOffset, float elasticDivider)
        {
            _slingShotController = slingShotController;
            _centerTransform = config.centerTransform;
            _idleTransform = config.idleTransform;
            _birdPositionOffset = birdPositionOffset;
            _elasticDivider = elasticDivider;

            _leftlineRenderer.enabled = false;
            _rightlineRenderer.enabled = false;
        }

        private void Update()
        {
            _slingShotController.UpdateSlingshot();
        }

        public void SpawnBirdAndSetSlingshotLines()
        {
            IsBirdOnSlingShot = true;

            SetSlingshotLines(_idleTransform.position);

            Vector2 direction = (_centerTransform.position - _idleTransform.position).normalized;
            Vector2 spawnPosition = (Vector2)_idleTransform.position + direction * _birdPositionOffset;

            _spawnedBird = Instantiate(_birdPrefab, spawnPosition, Quaternion.identity);
            _spawnedBird.transform.right = direction;
        }

        public void PositionAndRotateBird(Vector2 slingShotLinesPosition, Vector2 directionNormalized, float birdPositionOffset)
        {
            _spawnedBird.transform.position = slingShotLinesPosition + directionNormalized * birdPositionOffset;
            _spawnedBird.transform.right = directionNormalized;
        }

        public void SetSlingshotLines(Vector2 position)
        {
            if (!_leftlineRenderer.enabled && !_rightlineRenderer.enabled)
            {
                _leftlineRenderer.enabled = true;
                _rightlineRenderer.enabled = true;
            }

            _leftlineRenderer.SetPosition(0, position);
            _leftlineRenderer.SetPosition(1, _leftStartTransform.position);

            _rightlineRenderer.SetPosition(0, position);
            _rightlineRenderer.SetPosition(1, _rightStartTransform.position);
        }

        public void SpawnAnotherBird()
        {
            StartCoroutine(SpawnBirdAfterSomeTime());
        }

        public void AnimateSlingShot()
        {
            _elasticTransform.position = _leftlineRenderer.GetPosition(0);

            float distance = Vector2.Distance(_elasticTransform.position, _centerTransform.position);
            float time = distance / _elasticDivider;

            _elasticTransform.DOMove(_centerTransform.position, time).SetEase(_elasticCurve);
            StartCoroutine(AnimateSlingShotLines(_elasticTransform, time));
        }

        private IEnumerator SpawnBirdAfterSomeTime()
        {
            yield return new WaitForSeconds(Constants.TIME_TO_SPAWN_ANOTHER_BIRD);
            SpawnBirdAndSetSlingshotLines();
            GameService.Instance.GetCameraService().SwitchToIdleCamera();
        }

        private IEnumerator AnimateSlingShotLines(Transform transform, float time)
        {
            float elapsedTime = 0;
            while (elapsedTime < time)
            {
                elapsedTime += Time.deltaTime;
                SetSlingshotLines(transform.position);

                yield return null;
            }
        }

        public BirdView GetSpawnedBird() => _spawnedBird;
    }
}