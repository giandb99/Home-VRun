using System.Collections;
using TMPro;
using UnityEngine;

public class Ball : MonoBehaviour
{
    TMP_Text distanceText;
    UIManager manager;
    bool hit;
    private void Start()
    {
        distanceText = GameObject.Find("Metros").GetComponent<TMP_Text>();
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
    public IEnumerator distance()
    {
        yield return new WaitForSeconds(.05f);

    }
}
