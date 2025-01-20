using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [SerializeField] GameObject wy��czAudio;
    [SerializeField] GameObject w��czAudio;
    private static AudioManager instance;

    public AudioClip backgroud;
    public AudioClip �mier�;
    public AudioClip wygrana;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else { Destroy(gameObject); }
    }
    private void Start()
    {
        musicSource.clip = backgroud;
        musicSource.Play();
    }

    public void PlaySFC(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    public void wy��cz()
    {
        musicSource.volume = 0f;
        wy��czAudio.SetActive(false);
        w��czAudio.SetActive(true);
    }

    public void w��cz()
    {
        musicSource.volume = 0.055f;
        w��czAudio.SetActive(false);
        wy��czAudio.SetActive(true);
    }
}
