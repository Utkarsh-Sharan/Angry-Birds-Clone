using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Audio
{
    public class AudioService
    {
        private AudioController _audioController;

        public AudioService(AudioController audioController, List<AudioScriptableObject> audioSOList, AudioSource audioSource)
        {
            _audioController = audioController;
            _audioController.Init(audioSOList, audioSource);
        }

        public void PlaySound(AudioTypes audioType) => _audioController.PlaySound(audioType);
    }
}