using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour {

    Vector2 target;
    public float speed;
   
	// Use this for initialization
	void Start () {
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
       
	}
	
	// Update is called once per frame
	void Update () {
        if (!VirtualHandler.IsTouched())
            transform.position = Vector2.MoveTowards(transform.position,target,speed*Time.deltaTime);
        else
        {
            transform.position = Vector2.zero;
            Destroy(gameObject);
        }
        if (Vector2.Distance(transform.position, target) < 0.2f)
        {
            Destroy(gameObject);
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.tag.Equals("Enemy"))
        {
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.layer!=8)
        {
            Vibration.Vibrate(50);
            Destroy(gameObject);
        }
    }
}
