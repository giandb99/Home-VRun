using UnityEngine;

public class BatCollision : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();

            Vector3 velocidadBate = GetComponent<Rigidbody>().linearVelocity;
            rb.AddForce(velocidadBate * 2f, ForceMode.Impulse);
        }
    }
}
