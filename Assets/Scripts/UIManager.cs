using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Threading;
using System.Collections;

public class UIManager : MonoBehaviour
{
    TMP_Text timeText;
    TMP_Text scoreText;
    public int score;
    public int actualTime;
    private bool isLoadingScene = false;

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
        timeText.text = Mathf.Ceil(actualTime).ToString();
        yield return new WaitForSeconds(1f);
        actualTime--;
        if(actualTime != 0)
        {
            if (actualTime <= 10)
            {
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
            timeText = GameObject.Find("Timer").GetComponent<TMP_Text>();
            scoreText = GameObject.Find("Score").GetComponent<TMP_Text>();
            timeText.text = actualTime.ToString();
            scoreText.text = score.ToString();
            StartCoroutine(time());
        }
    }
    public void LoadEndScene()
    {
        SceneManager.LoadScene("EndScene");
    }
    public void SetScore()
    {
        scoreText.text = score.ToString();
    }
}
