using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyInstantiator : MonoBehaviour {

    public bool active;

    public GameObject candy;

	// Use this for initialization
	void Start () {
        active = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (active)
        {
            Instantiate(candy, this.gameObject.transform.position, Quaternion.identity);
            active = false;
        }
    }
}
