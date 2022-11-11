using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseButton : MonoBehaviour
{
    private Button button;
    private GameObject page;

    // Start is called before the first frame update
    void Start()
    {
        page = GameObject.Find("Pages");
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        page.SetActive(false);
    }
}
