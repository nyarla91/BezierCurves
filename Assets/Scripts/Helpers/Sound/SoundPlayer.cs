using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NyarlaEssentials.Sound
{
    public class SoundPlayer : MonoBehaviour
    {
        private const float MASTER_VOLUME = 0.4f;
    
        private static SoundPlayer _instance;
    
        [SerializeField] private GameObject _soundPrefab;

        private void Awake()
        {
            _instance = this;
        }

        public static void Play(AudioClip audioClip, float volume)
        {
            SoundInstance newInstance =
                Instantiate(_instance._soundPrefab, CameraProperties.instance.transform.position, Quaternion.identity)
                    .GetComponent<SoundInstance>();
            newInstance.Play(audioClip, volume * MASTER_VOLUME);
        }
    
    }

}