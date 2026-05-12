using UnityEngine;

public class Ball : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Field"))
        {
            tag = "Pickup";
        }
        if (collision.collider.CompareTag("Homerun"))
        {
            tag = "Pickup";
        }
    }
}
