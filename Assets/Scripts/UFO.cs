using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.UIElements;

public class UFO : MonoBehaviour
{
    public Transform routeFather;
    public bool recoger;
    public bool volver;
    Vector3 destination;
    [SerializeField] GameObject pitcher;

    private void Start()
    {
        volver = false;
        recoger = true;
        destination = new Vector3(routeFather.GetChild(0).position.x,transform.position.y, routeFather.GetChild(0).position.z);
        GetComponent<NavMeshAgent>().SetDestination(destination);
    }

    void Update()
    {
        Debug.Log(routeFather.GetChild(0).gameObject.transform.position);
        if (Vector3.Distance(transform.position, destination) < 0.5f)
        {
            if (volver)
            {
                volver = false;
                StartCoroutine(Refill());
            }
            if (recoger)
            {
                recoger = false;
                StartCoroutine(Abduction());
            }
        }
    }
    private IEnumerator Abduction()
    {
        yield return new WaitForSeconds(0.1f);
        if (routeFather.GetChild(0).position.y < 4)
        {
            routeFather.GetChild(0).GetComponent<Rigidbody>().AddForce(0,250,0);
            StartCoroutine(Abduction());
        }
        else
        {
            Destroy(routeFather.GetChild(0).gameObject);
            destination = new Vector3(pitcher.transform.position.x, transform.position.y, pitcher.transform.position.z);
            volver = true;
            GetComponent<NavMeshAgent>().SetDestination(destination);
        }
    }
    private IEnumerator Refill()
    {
        yield return new WaitForSeconds(1f);
        destination = new Vector3(routeFather.GetChild(0).position.x, transform.position.y, routeFather.GetChild(0).position.z);
        GetComponent<NavMeshAgent>().SetDestination(destination);
        recoger = true;
    }
}
