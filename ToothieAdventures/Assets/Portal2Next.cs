﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal2Next : MonoBehaviour {

    public string title;

	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.Equals("Player"))
        {
            GameManager.ToNextLvl(title);
        }
    }
}
