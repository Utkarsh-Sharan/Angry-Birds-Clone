using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    private Dictionary<AudioType, AudioClip> _audioClipDictionary;
    private AudioSource _audioSource;

    public void Init(List<AudioScriptableObject> audioSOList, AudioSource audioSource)
    {
        _audioClipDictionary = new Dictionary<AudioType, AudioClip>();
        _audioSource = audioSource;

        foreach (AudioScriptableObject audioData in audioSOList)
        {
            if (!_audioClipDictionary.ContainsKey(audioData.AudioType))
                _audioClipDictionary[audioData.AudioType] = audioData.AudioClip;
        }
    }

    public void PlaySound(AudioType audioType)
    {
        if(_audioClipDictionary.TryGetValue(audioType, out AudioClip clip))
        {
            _audioSource.clip = clip;
            _audioSource.PlayOneShot(_audioSource.clip);
        }
    }
}
