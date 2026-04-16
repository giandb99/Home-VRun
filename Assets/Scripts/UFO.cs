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
    public Vector3 min, max;
    [SerializeField] GameObject pitcher;
    [SerializeField] ParticleSystem abduct, expell;
    private void Start()
    {
        volver = false;
        recoger = true;
        destination = new Vector3(routeFather.GetChild(0).position.x, transform.position.y, routeFather.GetChild(0).position.z);
        GetComponent<NavMeshAgent>().SetDestination(destination);
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, destination) < 0.5f)
        {
            if (volver)
            {
                volver = false;
                expell.Play();
                StartCoroutine(Refill());
            }
            if (recoger)
            {
                recoger = false;
                abduct.Play();
                StartCoroutine(Abduction());
            }
        }
    }
    private IEnumerator Abduction()
    {
        yield return new WaitForSeconds(0.1f);
        if (routeFather.GetChild(0).position.y < 4)
        {
            routeFather.GetChild(0).GetComponent<Rigidbody>().AddForce(0, 250, 0);
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
        if (routeFather.childCount > 0)
        {
            destination = new Vector3(routeFather.GetChild(0).position.x, transform.position.y, routeFather.GetChild(0).position.z);
            GetComponent<NavMeshAgent>().SetDestination(destination);
            recoger = true;
        }
        else
        {
            StartCoroutine(Patrol());
        }
    }
    private void RandomDestination()
    {
        destination = new Vector3(Random.Range(min.x, max.x), transform.position.y, Random.Range(min.z, max.z));
        GetComponent<NavMeshAgent>().SetDestination(destination);
    }
    IEnumerator Patrol()
    {
        while (true)
        {
            if (Vector3.Distance(transform.position, destination) < 2.5f)
            {
                yield return new WaitForSeconds(Random.Range(0.1f, 1f));
                RandomDestination();
            }
            yield return new WaitForEndOfFrame();
        }
    }

}
