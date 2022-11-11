using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QRCode : MonoBehaviour
{
    public List<Texture2D> textures;
    private RawImage qrCodeTexture;
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
        qrCodeTexture = buttons[index - 1].transform.parent.parent.GetChild(1).GetChild(0).GetChild(0).GetComponent<RawImage>();
        qrCodeTexture.texture = textures[index - 1];
    }

    public void SetQRCode(int index)
    {
        qrCodeTexture = GameObject.Find("UICanvas").transform.GetChild(0).transform.GetChild(0).GetChild(0).gameObject.GetComponent<RawImage>();
        qrCodeTexture.texture = textures[index - 1];
    }

    DisplayButton[] DestinationSort(DisplayButton[] sortedButtons)
    {
        sortedButtons = sortedButtons.OrderBy(button => button.transform.parent.parent.GetSiblingIndex()).ToArray();
        return sortedButtons;
    }
}
