using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SplashScreen : MonoBehaviour {

    public Image splashImage;
    public string loadLevel;
    public AudioSource meow;
    public float time;
    IEnumerator Start()
    {
        splashImage.canvasRenderer.SetAlpha(0.0f);
        FadeIn();
        yield return new WaitForSeconds(time-1);
        meow.volume = 0.25f;
        meow.Play();
        yield return new WaitForSeconds(time/2);
        FadeOut();
        yield return new WaitForSeconds(time);
        if (SceneManager.sceneCount == 1)
            Application.Quit();
        else 
            SceneManager.LoadScene(loadLevel);
    }

    void FadeIn()
    {
        splashImage.CrossFadeAlpha(1.0f,3f,false);
    }

    void FadeOut()
    {
        splashImage.CrossFadeAlpha(0.0f, 2.5f, false);
    }

}
