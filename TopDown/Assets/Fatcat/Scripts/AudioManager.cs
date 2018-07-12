using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public static AudioManager instance;
    public AudioClip shoot;
    public AudioSource background;

    private void Awake()
    {
        if (AudioManager.instance == null)
        {
            AudioManager.instance = this;
        }
        else if (AudioManager.instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void ChangeSound(AudioClip cs)
    {
        background.clip = cs;
        background.volume = 0.5f;
        background.Play();
    }
    public void ShootSound()
    {
        ChangeSound(shoot);
    }

    public void SetActive(bool active)
    {
        this.enabled = active;
    }

    private void OnDestroy()
    {
        if (AudioManager.instance == this)
        {
            AudioManager.instance = null;
        }
    }
}
