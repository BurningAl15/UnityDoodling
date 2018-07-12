using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {

    Rigidbody2D rgb;
    Animator anim;

    public float speed;
    public int dir;

    public float jumpHeight;

    public bool isGround;

    public static bool isAlive;

    public GameObject particles;

	// Use this for initialization
	void Start () {
        rgb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        isAlive = true;
    }
	
	// Update is called once per frame
	void Update () {
        

        if(isAlive)
        {
            //this.GetComponent<Collider2D>().enabled = true;
            //this.enabled = true;
            anim.SetBool("IsAlive", isAlive);
            if (Input.GetMouseButtonDown(0) && isGround)
            {
                Jump();
            }
            else
            {
                Move();
            }
        }
        else
        {
            //rgb.AddForce(Vector2.up*300);
            //this.GetComponent<Collider2D>().enabled = false;
            //this.enabled = false;
            
            anim.SetTrigger("Die");
            Instantiate(particles, transform.position, Quaternion.identity);
        }
    }


    void Move()
    {
        Vector2 move = new Vector2(speed * dir, rgb.velocity.y);
        rgb.velocity = move;
        anim.SetBool("Ground", isGround);
    }


    void Jump()
    {
        Vector2 jump = new Vector2(0f, jumpHeight);
        rgb.velocity = jump;
        isGround = false;
        anim.SetTrigger("Jump");
        SoundManager.instance.PlayJump();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.Equals("Ground") || collision.tag.Equals("Brokable") || collision.tag.Equals("Button"))
        {
            isGround = true;
        }
    }
}
