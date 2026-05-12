using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public TMP_Text timeText;
    public TMP_Text scoreText;
    public int score = 100;

    public int maxTime = 15;
    private float actualTime;
    private bool isLoadingScene = false;

    public static UIManager instance; 

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timeText.text = maxTime.ToString();
        actualTime = maxTime;
        scoreText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (isLoadingScene) return;

        if (actualTime > 0)
        {
            if (actualTime <= 10)
            {
                timeText.color = Color.red;
            }
            actualTime -= Time.deltaTime;
            timeText.text = Mathf.Ceil(actualTime).ToString();
        }else
        {
            isLoadingScene = true;
            Debug.Log("TIME OVER");
            LoadEndScene();
        }
        
    }

    public void LoadEndScene()
    {
        SceneManager.LoadScene("EndScene");
    }
}
