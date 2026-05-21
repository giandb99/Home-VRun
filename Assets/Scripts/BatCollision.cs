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
        print(GetComponent<Rigidbody>().linearVelocity);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ball"))
        {
            AudioManager.instance.PlaySFX("BatHit");
            Rigidbody rb = collision.collider.GetComponent<Rigidbody>();

            Vector3 velocidadBate = GetComponent<Rigidbody>().linearVelocity;
            rb.AddForce(new Vector3(2000f,250f,2000f)+velocidadBate);
            print(rb.linearVelocity);
        }
    }
}
