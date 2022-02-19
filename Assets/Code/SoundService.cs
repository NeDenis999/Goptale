using UnityEngine;

namespace Code
{
    public class SoundService : MonoBehaviour
    {
        [SerializeField]
        private AudioSource _audioSource;

        public void PlayMusic(AudioClip audioClip = null)
        {
            if (!audioClip || _audioSource.clip == audioClip)
                return;

            _audioSource.clip = audioClip;
            _audioSource.Play();
        }
    }
}
