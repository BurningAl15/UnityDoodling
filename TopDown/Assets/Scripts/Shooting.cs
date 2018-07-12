using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

    public GameObject shot;
    TopDownPlayer player;
    public long shootVibration;
    // Use this for initialization
    void Start () {
        player = FindObjectOfType<TopDownPlayer>();
	}
	
	// Update is called once per frame
	void Update () {
        Shoot();
	}

    void Shoot()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (!VirtualHandler.IsTouched())
            {
                AudioManager.instance.ShootSound();
                Vibration.Vibrate(shootVibration);
                Instantiate(shot, player.transform.position, Quaternion.identity);
            }
        }
    }
}
