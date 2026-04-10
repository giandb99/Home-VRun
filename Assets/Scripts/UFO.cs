using UnityEngine;
using UnityEngine.AI;

public class UFO : MonoBehaviour
{
    public Transform routeFather;
    int indexChildren;
    Vector3 destination;

    private void Start()
    {
        destination = routeFather.GetChild(indexChildren).position;
        GetComponent<NavMeshAgent>().SetDestination(destination);
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, destination) < 2.5f)
        {
            indexChildren++;
            if (indexChildren >= routeFather.childCount)
                indexChildren = 0;
            destination = routeFather.GetChild(indexChildren).position;
            GetComponent<NavMeshAgent>().SetDestination(destination);
        }
    }
}
