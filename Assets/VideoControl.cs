using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoControl : MonoBehaviour
{

    private UnityEngine.Video.VideoPlayer videoPlayer;

    public GameObject gameCam;
    public bool isBegan = false;
    private bool isPaused = false;
    public bool isEnabled = true;
    private Vector3 oldPlace = new Vector3(0.17f,2.79f,-15.27f);
    public GvrAudioSource sourse;
    public Logic lg;
    public int PlayingState = 1;

    void Start()
    {
        videoPlayer = GetComponent<UnityEngine.Video.VideoPlayer>();

        if (videoPlayer.clip != null)
        {
            videoPlayer.EnableAudioTrack(0, true);
        }
    }

    //Check if input keys have been pressed and call methods accordingly.
    void Update()
    {
        //Play or pause the video.
        if (Input.GetMouseButton(0) && isBegan == true)
        {
            if (videoPlayer.isPlaying)
            {
                videoPlayer.Pause();
                sourse.Pause();
                isPaused = true;
            }
            else
            {
                videoPlayer.Play();
                if (isEnabled)
                    sourse.Play();
                isPaused = false;
            }
        }
        if (!isPaused && !videoPlayer.isPlaying && isBegan)
        {         
            if (PlayingState == 0 || PlayingState == 5)
            {
                sourse.Pause();
                isBegan = false;
                gameCam.transform.position = oldPlace;
            }
            else if(PlayingState == 1)
            {
                videoPlayer.url = lg.carUrl;
                videoPlayer.Play();
                PlayingState = 2;
            }
            else if(PlayingState == 2)
            {
                videoPlayer.url = lg.mountainUrl;
                videoPlayer.Play();
                PlayingState = 3;
            }
            else if(PlayingState == 3)
            {
                videoPlayer.url = lg.cliffUrl;
                videoPlayer.Play();
                PlayingState = 4;
            }
            else if(PlayingState == 4)
            {
                videoPlayer.url = lg.stationUrl;
                videoPlayer.Play();
                PlayingState = 5;
            }
        }

    }
}
