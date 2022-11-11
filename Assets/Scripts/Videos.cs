using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class Videos : MonoBehaviour
{
    public GameObject screen;
    public List<string> videoUrls;
    public List<string> videoNames;
    private VideoPlayer videoPlayer;
    private Text screenName;

    void Awake(){ videoPlayer = screen.GetComponent<VideoPlayer>(); }

    public void SetVideo(int index) { videoPlayer.url = videoUrls[index - 1]; }

    public void SetVideoName(int index) { screenName.text = videoNames[index - 1]; }

}
