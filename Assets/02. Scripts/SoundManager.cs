using UnityEngine;

namespace Cat
{
    public class SoundManager : MonoBehaviour
    {
        private AudioSource audioSource;

        public AudioClip introClip;
        public AudioClip bgmClip;
        public AudioClip jumpClip;
        public AudioClip hitSoundClip;

        public enum SoundType
        {
            Intro = 0,
            BGM = 1
        }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            audioSource = GetComponent<AudioSource>();
            SetBGMSound(SoundType.Intro);
        }

        public void SetBGMSound(SoundType currentSound)
        {
            switch (currentSound)
            {
                case SoundType.Intro:
                    audioSource.clip = introClip;
                    break;
                case SoundType.BGM:
                    audioSource.clip = bgmClip;
                    break;
                default:
                    break;
            }
            audioSource.playOnAwake = true;
            audioSource.volume = 0.5f;
            audioSource.loop = true;

            audioSource.Play();
        }

        public void OnJumpSound()
        {
            audioSource.PlayOneShot(jumpClip);
        }

        public void OnHitSound()
        {
            audioSource.PlayOneShot(hitSoundClip);
        }
    }
}

