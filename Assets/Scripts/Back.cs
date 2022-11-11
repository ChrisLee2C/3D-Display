using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Back : MonoBehaviour
{
    private Button button;
    private List<GameObject> pageList;
    private GameObject parentPage;

    // Start is called before the first frame update
    void Awake()
    {
        parentPage = transform.parent.gameObject;
        pageList = FindObjectOfType<MenuButton>().pages;
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        pageList[parentPage.transform.GetSiblingIndex() - 1].SetActive(true);
        parentPage.SetActive(false);
    }
}
