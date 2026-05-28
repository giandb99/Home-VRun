using System.Collections;
using UnityEngine;


public class BallFIring : MonoBehaviour
{

    public GameObject ballPrefab;
    public GameObject goldenBallPrefab;
    public Transform spawnPoint;
    public float interval = 2f;
    public Transform routeFather;

    void Start()
    {
        StartCoroutine(esperar());
    }

    public IEnumerator esperar()
    {
        yield return new WaitForSeconds(1f);
        InvokeRepeating("Shoot", 0f, interval);
    }

    public void Shoot()
    {
        int value = Random.Range(0, 4);
        GameObject ball;
        Rigidbody rb;
        if (value == 0)
        {
            ball = Instantiate(goldenBallPrefab, spawnPoint.position, spawnPoint.rotation);
            rb = ball.GetComponent<Rigidbody>();
        }
        else
        {
            ball = Instantiate(ballPrefab, spawnPoint.position, spawnPoint.rotation);
            rb = ball.GetComponent<Rigidbody>();
        }
        ball.transform.SetParent(null);

        float force = RandomForece();
        Vector3 direction = spawnPoint.forward + Vector3.up * Random.Range(0.05f, 0.1f);

        if (force >= 1900)
        {
            direction = spawnPoint.forward + Vector3.up * 0.09f;
            rb.AddForce(direction * force);
        }
        else
        {
            rb.AddForce(direction.normalized * force);
        }
        ball.transform.SetParent(routeFather);
    }

    public float RandomForece()
    {
        float randomForce = Random.Range(1850f, 2000f);

        return randomForce;
    }
}
