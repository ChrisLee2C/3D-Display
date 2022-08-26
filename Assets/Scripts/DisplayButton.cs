using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class DisplayButton : MonoBehaviour
{
    private GameObject screen;
    private GameObject moreUICanvas;
    private Videos videos;
    private VideoPlayer videoPlayer;
    private GameObject screenExit;
    private Button button;

    // Start is called before the first frame update
    void Awake()
    {
        screen = GameObject.Find("UICanvas").transform.GetChild(0).gameObject;
        moreUICanvas = GameObject.Find("More UI Canvas");
        videos = FindObjectOfType<Videos>();
        videoPlayer = screen.GetComponent<VideoPlayer>();
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    private int GetVideoIndex() { return gameObject.transform.parent.parent.GetSiblingIndex(); }

    private void OnClick()
    {
        screen.SetActive(true);
        screen.transform.GetChild(0).gameObject.SetActive(true);
        videos.SetVideo(GetVideoIndex());
        videoPlayer.Prepare();
        videoPlayer.Play();
        moreUICanvas.SetActive(false);
    }
}
