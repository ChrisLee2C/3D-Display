using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class OnlineVideoLoader : MonoBehaviour
{

    public VideoPlayer videoPlayer;

    // Start is called before the first frame update
    void Start()
    {
        videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
        videoPlayer.EnableAudioTrack(0, true);
        videoPlayer.Prepare();
    }
}
