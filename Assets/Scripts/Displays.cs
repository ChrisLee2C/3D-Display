using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Displays : MonoBehaviour
{
    //Select the gameObject with the script on it
    //Click on little lock icon in the inspector, at the top right corner
    //Click on the first image in your asset
    //Hold SHIFT key, and click on the last image you want to select.All the images in between should be selected.
    //Click and hold the list into the Images field in the inspector.
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

    private int GetImageIndex(GameObject button) { return button.transform.parent.parent.GetSiblingIndex(); }

    private void SetImage(int index)
    {
        displaySprites = buttons[index - 1].transform.parent.GetChild(0).GetComponent<RawImage>();
        displaySprites.texture = sprites[index - 1];
    }

    public void SetInformation(int index)
    {
        displaySprites = GameObject.Find("UICanvas").transform.GetChild(0).gameObject.GetComponent<RawImage>();
        displaySprites.texture = sprites[index - 1];
    }

    DisplayButton[] DestinationSort(DisplayButton[] sortedButtons)
    {
        sortedButtons = sortedButtons.OrderBy(button => button.transform.parent.parent.GetSiblingIndex()).ToArray();
        return sortedButtons;
    }
}

