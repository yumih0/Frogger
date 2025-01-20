using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [SerializeField] GameObject wy³¹czAudio;
    [SerializeField] GameObject w³¹czAudio;
    private static AudioManager instance;

    public AudioClip backgroud;
    public AudioClip œmieræ;
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

    public void wy³¹cz()
    {
        musicSource.volume = 0f;
        wy³¹czAudio.SetActive(false);
        w³¹czAudio.SetActive(true);
    }

    public void w³¹cz()
    {
        musicSource.volume = 0.055f;
        w³¹czAudio.SetActive(false);
        wy³¹czAudio.SetActive(true);
    }
}
