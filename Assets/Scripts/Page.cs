using UnityEngine;

public class Page : MonoBehaviour
{
    private GameObject next;
    private GameObject back;
    private MenuButton menuButton;

    private void Awake()
    {
        menuButton = FindObjectOfType<MenuButton>();
        back = gameObject.GetComponentInChildren<Back>().gameObject;
        next = gameObject.GetComponentInChildren<Next>().gameObject;
    }
    private void Start()
    {
        if (gameObject.transform.GetSiblingIndex() == 0)
        {
            next.SetActive(true);
            back.SetActive(false);
        }
        else if (gameObject.transform.GetSiblingIndex() == menuButton.pages.Count - 1)
        {
            next.SetActive(false);
            back.SetActive(true);
        }
        else
        {
            next.SetActive(true);
            back.SetActive(true);
        }
        if (gameObject.transform.GetSiblingIndex() != 0) { gameObject.SetActive(false); }
    }
}