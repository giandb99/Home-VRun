using System.Collections;
using TMPro;
using UnityEngine;

public class Ball : MonoBehaviour
{
    TMP_Text distanceText, scoreText1, scoreText2;
    UIManager manager;
    bool hit;
    int multiplicador = 1;
    float distanciaBola;
    GameObject jugador;
    private void Start()
    {
        if (gameObject.CompareTag("GoldenBall"))
        {
            multiplicador = 2;
        }
        distanceText = GameObject.Find("Metros").GetComponent<TMP_Text>();
        scoreText1 = GameObject.Find("Score1").GetComponent<TMP_Text>();
        scoreText2 = GameObject.Find("Score2").GetComponent<TMP_Text>();
        manager = GameObject.Find("UIManager").GetComponent<UIManager>();
        jugador = GameObject.Find("XR Origin (XR Rig)");

    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Bat"))
        {
            hit = true;
            manager.racha++;
            StartCoroutine(distance());
        }
        if (collision.collider.CompareTag("Field") && hit)
        {
            tag = "Pickup";
            if(distanciaBola < 30)
            {
                scoreText1.text = "Sencillo";
                scoreText2.text = "Sencillo";
                manager.score+=(1+manager.racha)*multiplicador;
            }
            else
            {
                if(distanciaBola < 60)
                {
                    scoreText1.text = "Doble";
                    scoreText2.text = "Doble";
                    manager.score += (2 + manager.racha) * multiplicador;
                }
                else
                {
                    scoreText1.text = "Triple";
                    scoreText2.text = "Triple";
                    manager.score += (3 + manager.racha) * multiplicador;
                }
            }
                manager.score++;
            manager.SetScore();
        }
        if (collision.collider.CompareTag("Field") && !hit)
        {
            scoreText1.text = "Fallo";
            scoreText2.text = "Fallo";
            manager.racha=0;
            tag = "Pickup";
        }
        if (collision.collider.CompareTag("Homerun") && hit)
        {
            tag = "Pickup";
            manager.score += (5 + manager.racha) * multiplicador;
            AudioManager.instance.PlaySFX2("Homerun");
            scoreText1.text = "HOME RUN";
            scoreText2.text = "HOME RUN";
            manager.SetScore();
        }
        if (collision.collider.CompareTag("Limit") && hit)
        {
            tag = "Pickup";
            manager.score += (10 + manager.racha) * multiplicador;
            AudioManager.instance.PlaySFX2("Homerun");
            scoreText1.text = "Efecto Túnel";
            scoreText2.text = "Efecto Túnel";
            manager.SetScore();
        }
    }
    public IEnumerator distance()
    {
        yield return new WaitForSeconds(.05f);
        distanciaBola = Vector3.Distance(gameObject.transform.position, jugador.transform.position);
        Debug.Log(distanciaBola);
        distanceText.text = Mathf.FloorToInt(distanciaBola * 10f) / 10f + "m";
        distanceText.color = new Color(1f, (1f-Mathf.Clamp01(distanciaBola / 100f)), 0);
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
