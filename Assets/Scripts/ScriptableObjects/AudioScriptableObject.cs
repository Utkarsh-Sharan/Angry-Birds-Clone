using UnityEngine;
using Audio;

[CreateAssetMenu(fileName = "AudioScriptableObject", menuName = "ScriptableObject/AudioScriptableObject")]
public class AudioScriptableObject : ScriptableObject
{
    public AudioTypes AudioTypes;
    public AudioClip AudioClip;
}
