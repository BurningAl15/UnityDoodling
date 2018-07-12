using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehaviour : MonoBehaviour {

    Rigidbody2D rgb;

    public float speed;
    public int dir;
    public int type;

    Vector2 move;

    public float rotationSpeed;
    public GameObject particles;

    Vector3 objPos;

    public bool doughnutOn;
   

	// Use this for initialization
	void Start () {
        rgb = GetComponent<Rigidbody2D>();
        doughnutOn = false;
        dir = 1;
    }
	
	// Update is called once per frame
	void Update () {

        switch (type)
        {
            default:
            case 0:
                if (doughnutOn)
            {
                killerDoughtNut();
            }
            break;
                case 1:
                    sweetHazard();
            break;
        }
    }

    void killerDoughtNut()
    {
        move = new Vector2(speed, rgb.velocity.y);
        rgb.velocity = move;

        rgb.MoveRotation(rgb.rotation + rotationSpeed * -1 * Time.deltaTime);

    }
    

    void sweetHazard()
    {        
        move = new Vector2(0f, speed*dir);
        rgb.velocity = move;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Brokable"))
        {
            objPos = collision.transform.position;
            Instantiate(particles, objPos, Quaternion.identity);
            collision.gameObject.SetActive(false);    
        }
        if (collision.tag.Equals("Player"))
        {
            PlayerBehaviour.isAlive = false;
        }

        if(collision.tag.Equals("Ground"))
        {
            doughnutOn = true;
        }

        //Pinchos
        if (collision.tag.Equals("Points") && type==1)
        {
            dir *= -1;
        }
    }

}
