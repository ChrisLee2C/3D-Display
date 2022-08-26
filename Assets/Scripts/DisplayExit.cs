using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayExit : MonoBehaviour
{
    private GameObject display;
    private GameObject moreUICanvas;
    private Button button;

    // Start is called before the first frame update
    void Awake()
    {
        display = GameObject.Find("UICanvas").transform.GetChild(1).gameObject;
        moreUICanvas = GameObject.Find("More UI Canvas");
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        display.SetActive(false);
        gameObject.SetActive(false);
        moreUICanvas.SetActive(true);
    }
}
