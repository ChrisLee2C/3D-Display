using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Displays : MonoBehaviour
{
    public GameObject display;
    public List<Texture2D> textures;
    private RawImage displayTexture;

    void Awake()
    {
        displayTexture = display.GetComponent<RawImage>();
    }

    public void SetImage(int i)
    {
        displayTexture.texture = textures[i];
    }
}
