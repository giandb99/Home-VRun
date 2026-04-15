using UnityEngine;


public class BallFIring : MonoBehaviour
{

    public GameObject ballPrefab;
    public Transform spawnPoint;
    public float interval = 2f;

    void Start()
    {
        InvokeRepeating("Shoot", 0f, interval); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot()
    {
        GameObject ball = Instantiate(ballPrefab, spawnPoint.position, spawnPoint.rotation);
        Rigidbody rb = ball.GetComponent<Rigidbody>();
        
        ball.transform.SetParent(null);

        float force = RandomForece();
        Vector3 direction = spawnPoint.forward + Vector3.up * Random.Range(0.05f, 0.1f);

        if (force >= 1900)
        {
            direction = spawnPoint.forward;
        }
        
        Debug.Log("Fuerza de disparo: "+force);
        rb.AddForce(direction.normalized * force);
    }

    public float RandomForece()
    {
        float randomForce = Random.Range(1500f, 2000f);

        return randomForce;
    }
}
