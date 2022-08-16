using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Video;

public class Videos : MonoBehaviour
{
    public GameObject screen;
    public List<VideoClip> videos;
    private VideoPlayer videoPlayer;

    void Awake()
    {
        videoPlayer = screen.GetComponent<VideoPlayer>();
        InitVideos(videos);
    }

    void InitVideos(List<VideoClip> videos)
    {
        for (int index = 0; index < videos.Capacity; index++)
        {
            //videos[index] = Path.;
        }
    }

    public void SetVideo(int i)
    {
        videoPlayer.clip = videos[i];
        //videoPlayer.url = videos[i].name;
    }
}
