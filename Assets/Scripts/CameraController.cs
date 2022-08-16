using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float rotationSpeed = 40;
    public FixedJoystick fixedJoystick;
    private bool isFreeMovement;
    private Camera mainCamera;
    private PlayerController pController;

    private void Awake()
    {
        mainCamera = Camera.main;
        pController = GetComponentInParent<PlayerController>();
        isFreeMovement = true;
    }

    private void Update()
    {
        CameraRotation(Input.GetAxis("Horizontal"));
        CameraRotation(fixedJoystick.Horizontal);
        if (Input.GetMouseButtonDown(1))
        {
            FreeMovement(true);
        }
        if (isFreeMovement == false)
        {
            FaceTarget(pController.destinations, pController.currentDestination);
        }
    }

    public void FreeMovement(bool free)
    {
        isFreeMovement = free;
    }

    public void FaceTarget(GameObject[] destinations, int current)
    { 
        var turnTowardNavSteeringTarget = destinations[current].transform.position;

        Vector3 direction = turnTowardNavSteeringTarget - transform.position;
        Vector3 rotation = new Vector3(0, direction.y, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, destinations[current].GetComponentInParent<Transform>().rotation, Time.deltaTime*5);
    }

    public void CameraRotation(float horizontalInput)
    {
        if(horizontalInput != 0)
        {
            FreeMovement(true);
        }
        Vector3 rotation = new Vector3(0, horizontalInput, 0);
        transform.GetComponentInParent<Transform>().Rotate(rotation * rotationSpeed * Time.deltaTime);
    }
}
