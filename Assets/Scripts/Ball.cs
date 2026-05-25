using System.Collections;
using TMPro;
using UnityEngine;

public class Ball : MonoBehaviour
{
    TMP_Text distanceText;
    UIManager manager;
    bool hit;
    GameObject jugador;
    private void Start()
    {
        distanceText = GameObject.Find("Metros").GetComponent<TMP_Text>();
        manager = GameObject.Find("UIManager").GetComponent<UIManager>();
        jugador = GameObject.Find("XR Origin (XR Rig)");

    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Bat"))
        {
            hit = true;
            StartCoroutine(distance());
        }
        if (collision.collider.CompareTag("Field") && hit)
        {
            tag = "Pickup";
            manager.score++;
            manager.SetScore();
        }
        else
        {
            distanceText.text = "Fallo";
            tag = "Pickup";
        }
        if (collision.collider.CompareTag("Homerun") && hit)
        {
            tag = "Pickup";
<<<<<<< Updated upstream
            manager.score+=2;
=======
            manager.score += 2;
            AudioManager.instance.PlaySFX2("Homerun");
            distanceText.text = "¡¡¡HOME RUN!!!";
>>>>>>> Stashed changes
            manager.SetScore();
        }
    }
    public IEnumerator distance()
    {
        yield return new WaitForSeconds(.05f);
        float distanciaBola = Vector3.Distance(gameObject.transform.position, jugador.transform.position);
        Debug.Log(distanciaBola);
        distanceText.text = Mathf.FloorToInt(distanciaBola * 10f) / 10f + "m";
        if (gameObject.tag.Equals("Pickup"))
        {
            yield return new WaitForSeconds(1.5f);
            yield break;
        }
        else
        {
            StartCoroutine(distance());
        }
    }
}
