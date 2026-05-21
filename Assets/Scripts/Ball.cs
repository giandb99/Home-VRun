using UnityEngine;

public class Ball : MonoBehaviour
{
    UIManager manager;
    bool hit;
    private void Start()
    {
        manager = GameObject.Find("UIManager").GetComponent<UIManager>();
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Bat"))
        {
            hit = true;
        Debug.Log("AAAA");
        }
        if (collision.collider.CompareTag("Field") && hit)
        {
            tag = "Pickup";
            manager.score++;
            manager.SetScore();
        }
        if (collision.collider.CompareTag("Homerun") && hit)
        {
            tag = "Pickup";
            manager.score+=2;
            manager.SetScore();
        }
    }
}
