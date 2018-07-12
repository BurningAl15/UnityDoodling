using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public static SoundManager instance;

    //public AudioClip audioClipShoot;
    public AudioClip audioClipJump;

    public AudioSource audioSource;
    private void Awake()
    {
        if (SoundManager.instance == null)
        {
            SoundManager.instance = this;
        }
        else if (SoundManager.instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void PlayJump()
    {
        PlayAudioClip(audioClipJump);
    }

    //public void PlayShoot()
    //{
    //    PlayAudioClip(audioClipShoot);
    //}

    private void PlayAudioClip(AudioClip audioClip)
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    private void OnDestroy()
    {
        if (SoundManager.instance == this)
        {
            SoundManager.instance = null;
        }
    }
}
