using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Displays : MonoBehaviour
{
    public List<Texture2D> sprites;
    private RawImage displaySprites;
    private DisplayButton[] buttons;

    void Awake()
    {
        buttons = DestinationSort(FindObjectsOfType<DisplayButton>());
        foreach (DisplayButton displayButton in buttons)
        {
            int index = GetImageIndex(displayButton.gameObject);
            SetImage(index);
        }
    }

    private int GetImageIndex(GameObject button) => button.transform.parent.parent.GetSiblingIndex(); 

    private void SetImage(int index)
    {
        displaySprites = buttons[index - 1].transform.parent.parent.GetChild(0).GetComponentInChildren<RawImage>();
        displaySprites.texture = sprites[index - 1];
    }

    public void SetInformation(int index)
    {
        displaySprites = GameObject.Find("UICanvas").transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<RawImage>();
        displaySprites.texture = sprites[index - 1];
    }

    DisplayButton[] DestinationSort(DisplayButton[] sortedButtons)
    {
        sortedButtons = sortedButtons.OrderBy(button => button.transform.parent.parent.GetSiblingIndex()).ToArray();
        return sortedButtons;
    }
}

