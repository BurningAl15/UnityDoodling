using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtomDestroyer : MonoBehaviour {

    bool playerDie;

    public float delay;
    float startingDelay;

    LevelManager lvl;
    int destroyed;
	// Use this for initialization
	void Start () {
        playerDie = false;
        startingDelay = delay;
        
        lvl = FindObjectOfType<LevelManager>();
        destroyed = 0;
    }
	
	// Update is called once per frame
	void Update () {
		
        if(!PlayerBehaviour.isAlive)
        {
            delay -= Time.deltaTime;
            if(delay<=0)
            {
                lvl.RespawnPlayer();
                PlayerBehaviour.isAlive = true;
                
                //GameManager.Restart();  
            }
        }

	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.Equals("Player"))
        {
            PlayerBehaviour.isAlive = false;
        }

        if(collision.tag.Equals("Obstacle"))
        {
            Destroy(collision.gameObject);
        }
        if (collision.tag.Equals("Rain"))
        {
            Destroy(collision.gameObject);
            destroyed++;
            Debug.Log("" + destroyed);
        }

    }


}
