using UnityEngine;

public class BatCollision : MonoBehaviour
{   void Update()
    {
        print(GetComponent<Rigidbody>().linearVelocity);
    }

    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.collider.CompareTag("Ball") || collision.collider.CompareTag("GoldenBall"))
        {
            AudioManager.instance.PlaySFX("BatHit");
            Rigidbody rb = collision.collider.GetComponent<Rigidbody>();

            Vector3 velocidadBate = GetComponent<Rigidbody>().linearVelocity;
            rb.AddForce(new Vector3(2000f,250f,2000f));
            print(rb.linearVelocity);
        }
    }
}
