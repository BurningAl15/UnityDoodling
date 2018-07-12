using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {

    bool paused;
    bool isPlaying;
    public GameObject pauseManager;
    public AudioSource background;

    string titles;

	// Use this for initialization
	void Start () {
        paused = false;
        if(pauseManager != null)
        { 
            pauseManager.SetActive(paused);
        }
        isPlaying = true;
        titles = "Title";
    }
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            Sound();
        }
    }

    public void Pause()
    {
        paused = !paused;
        if(paused)
        {
            pauseManager.SetActive(paused);
            Time.timeScale = 0f;
        }
        else
        {
            pauseManager.SetActive(paused);
            Time.timeScale = 1f;
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public static void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public void ReturnToTitle()
    {
        SceneManager.LoadScene(titles);
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Sound()
    {
        isPlaying = !isPlaying;
        if (isPlaying)
        {
            background.volume = 1f;
        }
        else
        {
            background.volume = 0f;
        }
    }

    public static void ToNextLvl(string name)
    {
        SceneManager.LoadScene(name);
        Time.timeScale = 1f;
    }

}
