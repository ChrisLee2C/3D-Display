using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Information : MonoBehaviour
{
    private GameObject display;
    private GameObject moreUICanvas;
    private GameObject displayExit;
    private GameObject zoomInButton;
    private GameObject zoomOutButton;
    private Displays displaysScript;
    private Button button;
    private Button exitButton;

    // Start is called before the first frame update
    void Awake()
    {
        display = GameObject.Find("UICanvas").transform.GetChild(0).gameObject;
        exitButton = display.GetComponentInChildren<Button>();
        zoomInButton = GameObject.Find("UICanvas").transform.GetChild(1).gameObject;
        zoomOutButton = GameObject.Find("UICanvas").transform.GetChild(2).gameObject;
        moreUICanvas = GameObject.Find("More UI Canvas");
        displaysScript = FindObjectOfType<Displays>();
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    private int GetImageIndex() => gameObject.transform.parent.parent.GetSiblingIndex(); 

    private void OnClick()
    {
        display.SetActive(true);
        display.transform.GetChild(0).gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);
        zoomInButton.SetActive(true);
        zoomOutButton.SetActive(true);
        displaysScript.SetInformation(GetImageIndex());
        moreUICanvas.SetActive(false);
    }
}
