using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class PlayerController : MonoBehaviour
{
    public GameObject[] destinations;
    public int currentDestination = 0;
    private Camera mainCamera;
    private Rigidbody character;
    private NavMeshAgent navMeshAgent;

    // Start is called before the first frame update
    void Awake()
    {
        character = GetComponent<Rigidbody>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        destinations = DestinationSort(GameObject.FindGameObjectsWithTag("Destination"));
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            SetDestinationToMousePosition();
        }
    }

    public void NewDestination(Transform target)
    {
        navMeshAgent.SetDestination(target.position);
    }

    public void SetCurrentDestination(int current)
    {
        currentDestination = current;
    }

    public void NextDestination(int next){
        if (currentDestination + next < 0)
        {
            currentDestination = destinations.Length - 1;
            navMeshAgent.SetDestination(destinations[currentDestination].transform.position);
        }
        else if (currentDestination + next >= destinations.Length)
        {
            currentDestination = 0;
            navMeshAgent.SetDestination(destinations[currentDestination].transform.position);
        }
        else
        {
            currentDestination += next;
            navMeshAgent.SetDestination(destinations[currentDestination].transform.position);
        }
    }

    GameObject[] DestinationSort(GameObject[] sortedDestinations)
    {
        sortedDestinations = sortedDestinations.OrderBy(destination => destination.transform.parent.GetSiblingIndex()).ToArray();
        return sortedDestinations;
    }

    void SetDestinationToMousePosition()
    {
        RaycastHit hit;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            navMeshAgent.SetDestination(hit.point);
        }
    }
}