using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBehaviour : MonoBehaviour {

    Rigidbody2D rgb;
    public float speed;
    public int dir;

    public int type;

    public float delay;
    float startingDelay;
    public float respawnDelay;
    public bool destroy;
    
    public GameObject particles;

    
	// Use this for initialization
	void Start () {
        rgb = GetComponent<Rigidbody2D>();
        if(type!=1)
        {
            particles = null;
        }
        startingDelay = delay;
        respawnDelay = delay;
    }
	
	// Update is called once per frame
	void Update () {
        switch (type)
        {
            default:
            case 0:
                roting();
                break;
            case 1:
                if(destroy)
                {
                    delay -= Time.deltaTime;
                    if(delay<=0)
                    {
                        delayDestruction();
                        Instantiate(particles, this.gameObject.transform.position, Quaternion.identity);
                        
                        delay = startingDelay;
                        destroy = false;
                    }
                   
                }
                
                
                break;
        }

    }

    void roting()
    {
        rgb.MoveRotation(rgb.rotation + speed *dir * Time.deltaTime);
    }

    void delayDestruction()
    {

        this.gameObject.SetActive(false);
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.Equals("Player") && type==1)
        {
            destroy = true;
        }
        if (collision.tag.Equals("Obstacle") && type == 1)
        {
            Destroy(collision.gameObject);
        }


    }

}
