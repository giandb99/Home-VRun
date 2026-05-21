using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource sfxSource;
    public AudioSource musicSource; 

   
    public Dictionary<string, AudioClip> sfxClips = new Dictionary<string, AudioClip>();
    public Dictionary<string, AudioClip> musicClips = new Dictionary<string, AudioClip>();

    
    private void Awake()
    {

        if (instance == null) instance = this;
        else { Destroy(gameObject); return; }

        DontDestroyOnLoad(gameObject);

        LoadSFXClips();
        LoadMusicClips();
    }

    private void LoadSFXClips()
    {
        sfxClips["Playball"] = Resources.Load<AudioClip>("SFX/Playball");
        sfxClips["ButtonClick"] = Resources.Load<AudioClip>("SFX/Button-click");
        sfxClips["Homerun"] = Resources.Load<AudioClip>("SFX/Homerun");
        sfxClips["NaveAbsorver"] = Resources.Load<AudioClip>("SFX/Nave-absorver");
        sfxClips["BatHit"] = Resources.Load<AudioClip>("SFX/Bat-hit");
    }

    private void LoadMusicClips()
    {
        musicClips["GameplayTheme"] = Resources.Load<AudioClip>("Music/GameplayTheme");
        musicClips["MenuTheme"] = Resources.Load<AudioClip>("Music/MenuTheme");
    }

    public void PlaySFX(string clipName)
    {
        if (sfxClips.ContainsKey(clipName))
        {
            sfxSource.clip = sfxClips[clipName];
            sfxSource.Play();
        }
        else Debug.LogWarning("El AudioClip " + clipName + " no se encontro en el diccionario de sfxClips.");
    }

    public void PlayMusic(string clipName)
    {
        if (!musicClips.ContainsKey(clipName))
        {
            Debug.LogWarning("El AudioClip " + clipName + " no se encontro en el diccionario de musicClips.");
            return;
        }

        AudioClip clipToPlay = musicClips[clipName];

        if (musicSource.clip == clipToPlay && musicSource.isPlaying)
        {
            return;
        }


        musicSource.clip = clipToPlay;
        musicSource.Play();

    }


    public void StopMusic()
    {
        musicSource.Stop();
        musicSource.clip = null;
    }

    public void StopSFX()
    {
        sfxSource.Stop();
        sfxSource.clip = null;
    }

}
