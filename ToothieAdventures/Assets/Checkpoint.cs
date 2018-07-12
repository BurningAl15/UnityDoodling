using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

    LevelManager lvl;

    Animator anim;

	// Use this for initialization
	void Start () {
        lvl = FindObjectOfType<LevelManager>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.Equals("Player"))
        {
            lvl.currentCheckpoint = gameObject;
            anim.SetTrigger("Active");
        }
    }
}
