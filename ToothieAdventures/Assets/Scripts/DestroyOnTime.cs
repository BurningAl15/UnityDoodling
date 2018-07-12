using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTime : MonoBehaviour {

    public float delay;


	// Update is called once per frame
	void Update () {
        delay -= Time.deltaTime;
        if(delay<=0)
        {
            Destroy(gameObject);
        }
	}
}
