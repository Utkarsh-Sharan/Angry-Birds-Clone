using System.Collections.Generic;
using UnityEngine;

namespace Audio
{
    public class AudioController : MonoBehaviour
    {
        private Dictionary<AudioTypes, AudioClip> _audioClipDictionary;
        private AudioSource _audioSource;

        public void Init(List<AudioScriptableObject> audioSOList, AudioSource audioSource)
        {
            _audioClipDictionary = new Dictionary<AudioTypes, AudioClip>();
            _audioSource = audioSource;

            foreach (AudioScriptableObject audioData in audioSOList)
            {
                if (!_audioClipDictionary.ContainsKey(audioData.AudioTypes))
                    _audioClipDictionary[audioData.AudioTypes] = audioData.AudioClip;
            }
        }

        public void PlaySound(AudioTypes audioType)
        {
            if (_audioClipDictionary.TryGetValue(audioType, out AudioClip clip))
            {
                _audioSource.clip = clip;
                _audioSource.Play();
            }
        }
    }
}