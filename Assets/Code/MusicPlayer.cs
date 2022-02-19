using UnityEngine;
using Zenject;

namespace Code
{
    public class MusicPlayer : MonoBehaviour
    {
        [SerializeField]
        private AudioClip _music;

        [Inject]
        public void Construct(SoundService soundService)
        {
            soundService.PlayMusic(_music);
        }
    }
}
