using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Threading;
using System.Collections;

public class UIManager : MonoBehaviour
{
    TMP_Text timeText;
    TMP_Text scoreText;
    public int score, racha;
    public int actualTime;

    public static UIManager instance; 

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame

    public IEnumerator time()
    {
        yield return new WaitForSeconds(1f);
        if (actualTime == 60)
        {
            timeText.text = "01:00";
        }
        timeText.text = "00:"+actualTime;
        actualTime--;
        if(actualTime != 0)
        {
            if (actualTime < 10)
            {
                timeText.text = "00:0" + actualTime;
                timeText.color = Color.red;
            }
            StartCoroutine(time());
        }
        else
        {
            LoadEndScene();
        }
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name.Equals("BasicScene"))
        {
            actualTime = 60;
            score = 0;
            racha = 0;
            timeText = GameObject.Find("Timer").GetComponent<TMP_Text>();
            scoreText = GameObject.Find("Score").GetComponent<TMP_Text>();
            timeText.text = "01:00";
            scoreText.text = score.ToString();
            SetScore();
            StartCoroutine(time());
        }
    }
    public void LoadEndScene()
    {
        SceneManager.LoadScene("EndScene");
    }
    public void SetScore()
    {
        scoreText.text = "Puntos: "+score+"\nRacha: "+racha;
    }
}
