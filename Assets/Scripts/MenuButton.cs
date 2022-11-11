using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
    [HideInInspector] public List<GameObject> pageButtons;
    [HideInInspector] public List<GameObject> pages;
    [SerializeField] private GameObject buttonPrefab;
    [SerializeField] private GameObject pagePrefab;
    [SerializeField] private Font font;
    private GameObject pageParent;
    private GameObject[] destinations;
    private List<string> videoNames;
    private int quotient;
    private int remainder;
    private int maxButtonNum = 10;
    private int numOfButton = 0;

    // Start is called before the first frame update
    void Awake()
    {
        destinations = FindObjectOfType<PlayerController>().destinations;
        videoNames = FindObjectOfType<Videos>().videoNames;
        quotient = destinations.Length / maxButtonNum;
        remainder = destinations.Length % maxButtonNum - 1;
        pageParent = GameObject.Find("Pages");
        CreatePage(quotient);
    }
    private void Start() { pageParent.SetActive(false); }

    private void CreatePage(int quotient)
    {
        print(destinations.Length);
        print("quotient " + quotient);
        print("remainder " + remainder);
        for (int times = 0; times < quotient + 1; times++)
        {
            GameObject page = Instantiate(pagePrefab, pageParent.transform.localPosition, Quaternion.identity, pageParent.transform);
            page.name = $"Page {times}";
            pages.Add(page);
            RectTransform pageRectTransform = page.GetComponent<RectTransform>();
            pageRectTransform.transform.localPosition = new Vector3(-pageRectTransform.rect.width / 2 + pageParent.transform.localPosition.x,
                -pageRectTransform.rect.height / 2 + pageParent.transform.localPosition.y, 0);
            CreateButton(times, page, page.transform.localPosition, page.transform.parent.transform.localPosition);
        }
    }

    private void CreateButton(int times, GameObject page, Vector3 pageTransform, Vector3 pageParentTransform)
    {
        if (times != quotient)
        {
            print("Button");
            for (int iter = 0; iter < maxButtonNum; iter++)
            {
                GameObject button = Instantiate(buttonPrefab, page.transform.localPosition, Quaternion.identity, page.transform);
                button.name = $"Button {iter}";
                print(button.name);
                button.GetComponent<PageButton>().InitButton(destinations[numOfButton + 1].transform, numOfButton + 1);
                button.GetComponent<PageButton>().GetName(videoNames[numOfButton], font);
                RectTransform buttonRectTransform = button.GetComponent<RectTransform>();
                buttonRectTransform.transform.localPosition = new Vector3(buttonRectTransform.rect.width / 2 + pageTransform.x - pageParentTransform.x,
                    buttonRectTransform.rect.height / 2 - pageTransform.y - pageParentTransform.y / 2 - iter * buttonRectTransform.rect.height, 0);
                numOfButton++;
            }
        }
        else
        {
            print("Last Button");
            for (int iter = 0; iter < remainder; iter++)
            {
                GameObject button = Instantiate(buttonPrefab, page.transform.localPosition, Quaternion.identity, page.transform);
                button.name = $"Button {iter}";
                print(button.name);
                button.GetComponent<PageButton>().InitButton(destinations[numOfButton + 1].transform, numOfButton + 1);
                button.GetComponent<PageButton>().GetName(videoNames[numOfButton], font);
                RectTransform buttonRectTransform = button.GetComponent<RectTransform>();
                buttonRectTransform.transform.localPosition = new Vector3(buttonRectTransform.rect.width / 2 + pageTransform.x - pageParentTransform.x,
                    buttonRectTransform.rect.height / 2 - pageTransform.y - pageParentTransform.y / 2 - iter * buttonRectTransform.rect.height, 0);
                numOfButton++;
            }
        }
    }
}