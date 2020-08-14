using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField] private AudioSource sfxAudioSource;
    [SerializeField] private AudioSource bgmAudioSource;

    [SerializeField] private AudioClip buttonClick;
    [SerializeField] private AudioClip slide;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void PlayClick()
    {
        sfxAudioSource.PlayOneShot(buttonClick);
    }

    public void PlaySlide()
    {
        sfxAudioSource.PlayOneShot(slide);
    }

    public void SetBgmActive(bool isActive)
    {
        if (isActive)
        {
            bgmAudioSource.volume = 0.04f;
        }
        else
            bgmAudioSource.volume = 0;
    }
}
