using UnityEngine;

[CreateAssetMenu(fileName = "SlingshotScriptableObject", menuName = "ScriptableObject/SlingshotScriptableObject")]
public class SlingshotScriptableObject : ScriptableObject
{
    public float MaxDistance;
    public float BirdPositionOffset;
    public float SlingshotForce;
    public float ElasticDivider;
}
