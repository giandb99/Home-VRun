using TMPro;
using UnityEngine;

public class FinalScore : MonoBehaviour
{

    public TMP_Text finalScore;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        finalScore.text = UIManager.instance.score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
