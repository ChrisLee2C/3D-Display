using UnityEngine;

public class FaceTarget : MonoBehaviour
{
    private CameraController cController;

    private void Awake()
    {
        cController = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<CameraController>();
    }

    void OnTriggerEnter(Collider other)
    {
        cController.FreeMovement(false);
    }
}
