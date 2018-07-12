using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public GameObject currentCheckpoint;
    PlayerBehaviour player;
    PlatformBehaviour[] platforms;
    // Use this for initialization
    void Start () {
        player = FindObjectOfType<PlayerBehaviour>();
        platforms =  FindObjectsOfType<PlatformBehaviour>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    public void RespawnPlayer()
    {
        player.transform.position = currentCheckpoint.transform.position;
        for(int i=0;i<platforms.Length;i++)
        {
            platforms[i].gameObject.SetActive(true);
        }
    }
}
