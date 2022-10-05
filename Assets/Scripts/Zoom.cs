using UnityEngine;
using UnityEngine.EventSystems;

public class Zoom : MonoBehaviour
{
    [SerializeField] private GameObject displayImage;
    private Vector3 initialScale;
    [SerializeField] private float maxZoom = 4f;

    private void Awake()
    {
        initialScale = displayImage.transform.localScale;
    }

    public void ZoomIn()
    {
        var delta = Vector3.one;
        var desiredScale = displayImage.transform.localScale + delta;

        desiredScale = ClampDesiredScale(desiredScale);

        displayImage.transform.localScale = desiredScale;
    }

    public void ZoomOut()
    {
        var delta = -Vector3.one;
        var desiredScale = displayImage.transform.localScale + delta;

        desiredScale = ClampDesiredScale(desiredScale);

        displayImage.transform.localScale = desiredScale;
    }

    private Vector3 ClampDesiredScale(Vector3 desiredScale)
    {
        desiredScale = Vector3.Max(initialScale, desiredScale);
        desiredScale = Vector3.Min(initialScale * maxZoom, desiredScale);
        return desiredScale;
    }
}