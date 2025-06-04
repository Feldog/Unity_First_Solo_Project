using UnityEngine;

namespace Cat
{
    public class SoundManager : MonoBehaviour
    {
        public AudioSource audioSource;
        public AudioClip bgmClip;
        public AudioClip jumpClip;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            SetBGMSound();
        }

        public void SetBGMSound()
        {
            audioSource.clip = bgmClip;
            audioSource.playOnAwake = true;
            audioSource.volume = 0.5f;
            audioSource.loop = true;

            audioSource.Play();
        }
        public void OnJumpSound()
        {
            audioSource.PlayOneShot(jumpClip);
        }
    }
}

