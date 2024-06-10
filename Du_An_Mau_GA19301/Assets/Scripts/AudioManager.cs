using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource musicaudioSource;
    public AudioSource vfxAudioSource;

    public AudioClip background;
    public AudioClip coin;
    public AudioClip Jump;
    public AudioClip win;
    public AudioClip bullet;

    private void Start()
    {
        musicaudioSource.clip = background;
        musicaudioSource.Play();
    }

    public void PlaySFX(AudioClip sfxclip)
    {
        vfxAudioSource.clip = sfxclip;
        vfxAudioSource.PlayOneShot(sfxclip);
    }
}
