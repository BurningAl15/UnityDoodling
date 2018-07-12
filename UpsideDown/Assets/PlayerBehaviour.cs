using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {

    Rigidbody2D rgb;

    public KeyCode left, right, jump,shoot;
    KeyCode[] keys;

    int dir;
    public float speed;

    public float jumpHeight;
    bool onGround;

    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask whatIsGround;

    public float delay;
    float startingDelay;

    //Random Value
    List<int> list;
    int[] randomValues = { 0, 1, 2,3 };

    public GameObject snowBall;
    public Transform launchPos;

	// Use this for initialization
	void Start () {
        rgb = GetComponent<Rigidbody2D>();
        keys = new KeyCode[4];
        keys[0] = left;
        keys[1] = right;
        keys[2] = jump;
        keys[3] = shoot;
        list = new List<int>();
        list.AddRange(randomValues);
        startingDelay = delay;
        
    }
	
    int GetUniqueRandom()
    {

        if (list.Count == 0)
        {
            list.AddRange(randomValues);
        }
        int index = Random.Range(0, list.Count);
        int i = list[index];
        list.RemoveAt(index);
        return i;

    }

    // Update is called once per frame
    void Update () {
        Move();
        Jump();
        Shoot();

        delay -= Time.deltaTime;
        if(delay<=0)
        {        
            left = keys[GetUniqueRandom()];
            right = keys[GetUniqueRandom()];
            jump = keys[GetUniqueRandom()];
            shoot = keys[GetUniqueRandom()];
            delay = startingDelay;
        }

    }

    void Move()
    {
        if(Input.GetKey(left))
        {
            dir = -1;
        }
        else if(Input.GetKey(right))
        {
            dir = 1;
        }
        else if(Input.GetKeyUp(left) || Input.GetKeyUp(right))
        {
            dir = 0;
        }

        if(onGround)
        {
            rgb.velocity = new Vector3(speed * dir, rgb.velocity.y);
        }
        else if(!onGround)
        {
            rgb.velocity = new Vector3(rgb.velocity.x, rgb.velocity.y);
        }

        if (rgb.velocity.x < 0)
        {
            rgb.transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (rgb.velocity.x > 0)
        {
            rgb.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    void Jump()
    {
        onGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGround);
        if(Input.GetKeyDown(jump) && onGround)
        {
            rgb.velocity = new Vector2(rgb.velocity.x, jumpHeight);
            onGround = false;
        }
    }

    void Shoot()
    {
        if(Input.GetKeyDown(shoot))
        {
            Instantiate(snowBall, launchPos.position, this.transform.rotation);
        }
    }

}
