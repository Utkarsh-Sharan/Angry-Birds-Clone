using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioScriptableObject", menuName = "ScriptableObject/AudioScriptableObject")]
public class AudioScriptableObject : ScriptableObject
{
    public AudioType AudioType;
    public AudioClip AudioClip;
}
