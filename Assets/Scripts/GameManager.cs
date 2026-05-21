using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AudioManager.instance.StopMusic();
        AudioManager.instance.PlaySFX("Playball");
        StartCoroutine(WaitForMusicToPlay());
    }

    IEnumerator WaitForMusicToPlay()
    {
        yield return new WaitForSeconds(1);
        AudioManager.instance.PlayMusic("GameplayTheme");
    }
}
