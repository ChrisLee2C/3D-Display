using UnityEngine;
using UnityEngine.UI;

public class PageButton : MonoBehaviour
{
    private PlayerController playerController;
    private CameraController cameraController;
    private Button button;
    private Text buttonText;
    private Transform transform;
    private int currentDestination;
    private string buttonName;
    private Font buttonFont;

    // Start is called before the first frame update
    void Awake()
    {
        buttonText = gameObject.GetComponentInChildren<Text>();
        playerController = FindObjectOfType<PlayerController>();
        cameraController = FindObjectOfType<CameraController>();
        button = GetComponent<Button>();
    }

    private void Start()
    {
        buttonText.font = buttonFont;
        buttonText.text = buttonName;
    }

    public void InitButton(Transform destinationTransform, int index)
    {
        transform = destinationTransform;
        currentDestination = index;
        button.onClick.AddListener(OnClick);
    }

    public void GetName(string name, Font font)
    {
        buttonName = name;
        buttonFont = font;
    }

    public void OnClick()
    {
        playerController.NewDestination(transform);
        playerController.SetCurrentDestination(currentDestination);
        cameraController.FreeMovement(true);
    }
}
