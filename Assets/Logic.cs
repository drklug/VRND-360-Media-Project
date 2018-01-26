using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class Logic : MonoBehaviour {

    public GameObject gameObject;
    public VideoControl controller;
    private UnityEngine.Video.VideoPlayer videoPlayer;
    public GameObject sphere;
    public GvrAudioSource sourse;
    public GvrAudioSource sourse2;

    public Text text1;
    public Text text2;
    public Button b1;
    public Button b2;

    private bool state1 = true;
    private bool state2 = true;

    private ColorBlock cb = new ColorBlock();

    public string breakfastUrl = "https://www.dropbox.com/s/hghcb03wgoin7dx/breakfast.mp4?dl=1";
    public string mountainUrl = "https://www.dropbox.com/s/om6v0p22d6y34b7/car_1.mp4?dl=1";
    public string cliffUrl = "https://www.dropbox.com/s/cag0nlxuvhmobrx/car_2.mp4?dl=1";
    public string carUrl = "https://www.dropbox.com/s/ifq30kdhmsbo0w0/car.mp4?dl=1";
    public string stationUrl = "https://www.dropbox.com/s/lntare2lvm37hit/car_3.mp4?dl=1";

    // Use this for initialization
    void Start () {
		videoPlayer = sphere.GetComponent<UnityEngine.Video.VideoPlayer>();
        cb.normalColor = Color.white;
        cb.pressedColor = Color.red;
        b1.colors = cb;
        b2.colors = cb;

    }
	
	// Update is called once per frame
	void Update () {

	}
    public void ToggleUI()
    {
        videoPlayer.Play();
        gameObject.transform.position = new Vector3(0f, 0f, 0f);
        controller.isBegan = true;
        if (state2)
            sourse2.Play();
    }
    public void changeState1()
    {
        if (state1)
        {
            state1 = false;
            text1.text = "Disabled";
            sourse.Pause();
        }
        else
        {
            state1 = true;
            text1.text = "Enabled";
            sourse.Play();
        }
    }
    public void changeState2()
    {
        if (state2)
        {
            state2 = false;
            text2.text = "Disabled";
            controller.isEnabled = false;
        }
        else
        {
            state2 = true;
            text2.text = "Enabled";
            controller.isEnabled = true;
        }
    }
    public void PlayWhole()
    {
        videoPlayer.url = breakfastUrl;
        controller.PlayingState = 1;
        ToggleUI();
    }
    public void PlayCliff()
    {
        videoPlayer.url = cliffUrl;
        controller.PlayingState = 0;
        ToggleUI();
    }
    public void PlayCar()
    {
        videoPlayer.url = carUrl;
        controller.PlayingState = 0;
        ToggleUI();
    }
    public void PlayStation()
    {
        videoPlayer.url = stationUrl;
        controller.PlayingState = 0;
        ToggleUI();
    }
    public void PlayMountain()
    {
        videoPlayer.url = mountainUrl;
        controller.PlayingState = 0;
        ToggleUI();
    }
}
