using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private void Start()
    {
        AudioManager.instance.PlayMusic("MenuTheme");
    }
    public void StartGame()
    {
        //SceneManager.LoadScene("BasicScene");
        SceneManager.LoadScene("BasicScene");
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Exiting the game...");
    }
}