using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource sfxSource;
    public AudioSource musicSource; 
    public AudioSource sfxSource2; 
    public AudioSource sfxUFO; 
   
    public Dictionary<string, AudioClip> sfxClips = new Dictionary<string, AudioClip>();
    public Dictionary<string, AudioClip> sfxClips2 = new Dictionary<string, AudioClip>();
    public Dictionary<string, AudioClip> sfxUFOClips = new Dictionary<string, AudioClip>();
    public Dictionary<string, AudioClip> musicClips = new Dictionary<string, AudioClip>();

    
    private void Awake()
    {

        if (instance == null) instance = this;
        else { Destroy(gameObject); return; }

        DontDestroyOnLoad(gameObject);

        LoadSFXClips();
        LoadSFXClips2();
        LoadSFXCUFO();
        LoadMusicClips();
    }

    private void LoadSFXClips()
    {
        sfxClips["ButtonClick"] = Resources.Load<AudioClip>("SFX/Button-click");
        sfxClips["BatHit"] = Resources.Load<AudioClip>("SFX/Bat-hit");
    }

    private void LoadSFXClips2()
    {
        sfxClips2["Playball"] = Resources.Load<AudioClip>("SFX/Playball");
        sfxClips2["Homerun"] = Resources.Load<AudioClip>("SFX/Homerun");
    }
    private void LoadSFXCUFO()
    {
        sfxUFOClips["NaveAbsorver"] = Resources.Load<AudioClip>("SFX/Nave-absorver");
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

    public void PlaySFX2(string clipName)
    {
        if (sfxClips2.ContainsKey(clipName))
        {
            sfxSource2.clip = sfxClips2[clipName];
            sfxSource2.Play();
        }
        else Debug.LogWarning("El AudioClip " + clipName + " no se encontro en el diccionario de sfxClips.");
    }
    public void PlaySFXUFO(string clipName)
    {
        if (sfxUFOClips.ContainsKey(clipName))
        {
            sfxUFO.clip = sfxUFOClips[clipName];
            sfxUFO.Play();
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
    public void StopSFX2()
    {
        sfxSource2.Stop();
        sfxSource2.clip = null;
    }
    public void StopSFXUFO()
    {
        sfxUFO.Stop();
        sfxUFO.clip = null;
    }

}
