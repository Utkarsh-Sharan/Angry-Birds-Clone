using UnityEngine;

namespace Slingshot
{
    public class SlingShotModel
    {
        public float MaxDistance { get; }
        public float BirdPositionOffset { get; }
        public float SlingshotForce { get; }
        public float ElasticDivider { get; }
        public Vector2 SlingshotLinesPosition { get; set; }
        public Vector2 Direction { get; set; }
        public Vector2 DirectionNormalized { get; set; }

        public SlingShotModel(SlingshotScriptableObject slingshotSO)
        {
            MaxDistance = slingshotSO.MaxDistance;
            BirdPositionOffset = slingshotSO.BirdPositionOffset;
            SlingshotForce = slingshotSO.SlingshotForce;
            ElasticDivider = slingshotSO.ElasticDivider;
        }
    }
}