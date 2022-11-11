using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenExit : MonoBehaviour
{
    private GameObject screen;
    private GameObject moreUICanvas;
    private Button button;

    // Start is called before the first frame update
    void Awake()
    {
        screen = GameObject.Find("UICanvas").transform.GetChild(0).gameObject;
        moreUICanvas = GameObject.Find("More UI Canvas");
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        screen.SetActive(false);
        gameObject.SetActive(false);
        moreUICanvas.SetActive(true);
    }
}
