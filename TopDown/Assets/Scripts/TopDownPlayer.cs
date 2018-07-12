using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownPlayer : MonoBehaviour {

    Rigidbody2D rgb;
    [Header("Movement Stuff")]
    public float speed;
    Vector2 moveVelocity;

    [Header("Health")]
    [SerializeField]
    PlayerHealth health;

    [Header("Animation")]
    public float size;
    public float val;

    [Header("Animation")]
    public VirtualHandler jsMovement;

    public long getVibration, hurtVibration;

    public GameObject death;

    // Use this for initialization
    void Start () {
        rgb = GetComponent<Rigidbody2D>();
        health = GetComponent<PlayerHealth>();
        jsMovement = FindObjectOfType<VirtualHandler>();
    }
	
	// Update is called once per frame
	void Update () {
        //if (health.isAlive)
            Move();
        //else
        //    moveVelocity = Vector3.zero;
        //Animation();
	}
    private void FixedUpdate()
    {
        rgb.velocity = moveVelocity;
    }

    void Move()
    {
        //Vector2 movement= new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector2 movement = new Vector2(jsMovement.Horizontal(),jsMovement.Vertical());
        moveVelocity = movement.normalized * speed;
    }

    public void Animation()
    {
        var localScale = new Vector3(1f, 1f, 1f) * 0.4f;

        var time = Time.fixedDeltaTime;
        var v = localScale * Mathf.Sin(time*val) * size;

        transform.localScale = v;
        
        var a = Instantiate(death, transform.position, transform.rotation);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8) { 
            if (collision.tag.Equals("Cure"))
            {
                Vibration.Vibrate(getVibration);
                health.Cure();
            }

            if (collision.tag.Equals("Hurt"))
            {
                Vibration.Vibrate(hurtVibration);
                health.Hurt();
            }

            Destroy(collision.gameObject);
        }
        if(collision.tag.Equals("Enemy"))
        {
            Vibration.Vibrate(hurtVibration);
            health.Hurt();
        }
    }
}
