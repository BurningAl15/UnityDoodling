using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour {

    public Transform player;

    //Must be into the range of 0 and 1
    public float smoothSpeed;

    public Vector3 offset;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 newPos= player.transform.position + offset;
        Vector3 smoothedPos = Vector3.Lerp(transform.position, newPos, smoothSpeed);
        this.transform.position = smoothedPos;

        transform.LookAt(player);
    }
}
