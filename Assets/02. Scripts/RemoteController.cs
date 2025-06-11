using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class RemoteController : MonoBehaviour
{
    [Header("Video Screen")][Space(3f)]
    public GameObject videoScreen;
    private VideoPlayer videoPlayer;

    [Header("Buttons")][Space(3f)]
    [Tooltip("Button to toggle the video screen")]
    public Button powerBtn;
    [Tooltip("Button to mute/unmute the video player")]
    public Button muteBtn;
    [Tooltip("Button to go to the previous video")]
    public Button prevBtn;
    [Tooltip("Button to go to the next video")]
    public Button nextBtn;

    [Header("Bool Data")][Space(3f)]
    public bool isOn;
    public bool isMute;

    [Header("Video Clips")][Space(3f)]
    public VideoClip[] videoClips;
    private int videoIndex = 0;

    private void Awake()
    {
        // Component initialization
        videoPlayer = videoScreen.GetComponent<VideoPlayer>();
    }

    private void Start()
    {
        //init video player value settings
        isOn = videoScreen.activeSelf;
        isMute = videoPlayer.GetDirectAudioMute(0);

        //button listeners setting
        powerBtn.onClick.AddListener(OnScreenPower);
        muteBtn.onClick.AddListener(OnMute);
        prevBtn.onClick.AddListener(OnPrevVideo);
        nextBtn.onClick.AddListener(OnNextVideo);

        //video player initialization
        videoPlayer.clip = videoClips[videoIndex];
    }

    public void OnScreenPower()
    {
        //Screen Toggle
        isOn = !isOn;
        videoScreen.SetActive(isOn);
    }

    public void OnMute()
    {
        //video Mute Toggle
        isMute = !isMute;
        videoPlayer.SetDirectAudioMute(0, isMute);
    }
    
    public void OnPrevVideo()
    {
        //Previous Video
        videoIndex--;
        if (videoIndex < 0)
        {
            videoIndex = videoClips.Length - 1; // Loop to the last video
        }
        videoPlayer.clip = videoClips[videoIndex];
        videoPlayer.SetDirectAudioMute(0, isMute);
        videoPlayer.Play();
    }
    public void OnNextVideo()
    {
        //Next Video
        videoIndex++;
        if (videoIndex >= videoClips.Length)
        {
            videoIndex = 0; // Loop to the first video
        }
        videoPlayer.clip = videoClips[videoIndex];
        videoPlayer.SetDirectAudioMute(0, isMute);
        videoPlayer.Play();
    }
}
