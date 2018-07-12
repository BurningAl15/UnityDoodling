using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartManager : MonoBehaviour {
    string game;
	// Use this for initialization
	void Start () {
        game = "Game";
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Play()
    {
        SceneManager.LoadScene(game);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
