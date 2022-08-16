using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QRCode : MonoBehaviour
{
    public GameObject qrCode;
    public List<Texture2D> textures;
    private RawImage qrCodeTexture;

    void Start()
    {
        qrCodeTexture = qrCode.GetComponent<RawImage>();
    }

    public void SetImage(int i)
    {
        qrCodeTexture.texture = textures[i];
    }
}
